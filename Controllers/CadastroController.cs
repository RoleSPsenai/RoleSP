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
        public IActionResult Criar(string usuarioCadastro, string emailCadastro, string senhaCadastro, string confirmarCadastro)
        {
            if (string.IsNullOrWhiteSpace(usuarioCadastro) || string.IsNullOrWhiteSpace(emailCadastro) ||
            string.IsNullOrWhiteSpace(senhaCadastro) || string.IsNullOrWhiteSpace(confirmarCadastro))
            {
                return Json(new { sucesso = false, mensagem = "Preencha todos os campos" });
            }
            if (senhaCadastro != confirmarCadastro)
            {
                return Json(new { sucesso = false, mensagem = "As senhas não conferem" });
            }
            if (_context.Usuarios.Any(u => u.Email == emailCadastro))
            {
                return Json(new { sucesso = false, mensagem = "E-mail já cadastrado" });
            }

            byte[] hash = HashService.GerarHashBytes(senhaCadastro);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Icon/iconUserDefault.png");
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string base64 = Convert.ToBase64String(bytes);

            Usuario usuario = new Usuario
            {
                Nome = usuarioCadastro,
                Apelido = usuarioCadastro,
                Email = emailCadastro,
                SenhaHash = hash,
                ImagemPerfil =  base64
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return  Json(new { sucesso = true });
        }
    }
}