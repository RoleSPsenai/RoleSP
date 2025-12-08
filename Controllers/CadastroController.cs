using Microsoft.AspNetCore.Mvc;
using RoleSP.Data;

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
                return Json(new { sucesso = false, mensagem = "Preencha todos os compos" });
            }
            if (senha !=  confirmar)
            {
                return Json(new{ sucesso = false, mensagem = "As senhas não conferem"});
            }
            if(_context.Usuarios.Any(u => u.Email == email))
            {
            
            }
        }
    }
}