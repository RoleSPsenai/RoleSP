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
            var ID_User = HttpContext.Session.GetInt32("ID_User");

            if(ID_User == null)
            {
                return RedirectToAction("Index","Login");
            }
            return RedirectToAction("Index", "Home");
        }
    
    }
}