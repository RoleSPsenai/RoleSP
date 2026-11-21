using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RoleSP.Data;
using RoleSP.Models;
using System.IO;
using Sistema_Login.Services;

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
            int? ID_User = HttpContext.Session.GetInt32("IdUsuario");
            
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
                return Json(new { sucesso = false, mensagem = "E-mail já cadastrado", });
            }

            byte[] hash = HashService.GerarHashBytes(senha);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Icon/iconUserDefault.png");
            byte[] fotoPadraoBytes = System.IO.File.ReadAllBytes(path);

            Usuario usuario = new Usuario
            {
                NomeUsuario = nome,
                Apelido = nome,
                Email = email,
                Senha = hash,
                Foto = fotoPadraoBytes,
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Json(new { sucesso = true , RedirectUrl = Url.Action("Login", "Index") });
        }
    }
}