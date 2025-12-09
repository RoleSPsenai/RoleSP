using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace RoleSP.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult Index(){
        return View();
        }

    public IActionResult VerificarAcesso()
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if(usuarioId == null)
            {
                return RedirectToAction("Index","Login");
            }
            return RedirectToAction("Dashboard", "Dashboard");
        }
    
    }
}