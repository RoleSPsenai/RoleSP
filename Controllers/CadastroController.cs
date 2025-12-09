using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RoleSP.Data;
using RoleSP.Models;
using Sistema_Login.Service;

namespace RoleSP.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(string nome, string email, string senha, string confirmar)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(confirmar))
            {
                return Json(new { sucesso = false, mensagem = "Preencha todos os campos" });
            }
            if (senha != confirmar)
            {
                return Json(new { sucesso = false, mensagem = "As senhas não conferem" });
            }
            if (_context.Usuarios.Any(u => u.Email == email))
            {
                return Json(new { sucesso = false, mensagem = "E-mail já cadastrado" });
            }

            byte[] hash = HashService.GerarHashBytes(senha);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/icon/UserDefault.png");
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string base64 = Convert.ToBase64String(bytes);

            Usuario usuario = new Usuario
            {
                Nome = nome,
                Apelido = nome,
                Email = email,
                SenhaHash = hash,
                ImagemPerfil =  base64
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Json(new { sucesso = true });
        }
    }
}