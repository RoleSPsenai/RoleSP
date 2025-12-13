using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RoleSP.Models;

namespace RoleSP.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerificarAcesso()
    {
        var ID_User = HttpContext.Session.GetInt32("IdUsuario");

        if (ID_User == null)
        {
            return RedirectToAction("Index", "Login");
        }
        return RedirectToAction("Home", "Home");
    }

}
