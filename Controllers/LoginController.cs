
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoleSP.Data;
using Sistema_Login.Service;

namespace RoleSP.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entrar(string user, string senha)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(senha))
            {
                return Json(new { sucesso = false, mensagem = "Preencha todos os campos" });
            }

            byte[] senhaDigitadaHash = HashService.GerarHashBytes(senha);

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nome == user);

            if (usuario == null || !usuario.SenhaHash.SequenceEqual(senhaDigitadaHash))
            {
                return Json(new { sucesso = false, mensagem = "Nome ou senha incorretos." });
            }

            HttpContext.Session.SetString("UsuarioNome", usuario.Nome ?? "");
            HttpContext.Session.SetInt32("UsuarioId", usuario.ID_User);

            return Json(new { sucesso = true });
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}