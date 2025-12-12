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
        var usuarioId = HttpContext.Session.GetInt32("ID_User");

        if (usuarioId == null)
        {
            return RedirectToAction("Index", "Login");
        }
        return RedirectToAction("Home", "Home");
    }

}
