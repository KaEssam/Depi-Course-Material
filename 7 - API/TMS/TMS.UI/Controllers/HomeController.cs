using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TMS.UI.Models;

namespace TMS.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Redirect to Tasks if authenticated, otherwise to Login
        if (!string.IsNullOrEmpty(HttpContext.Session.GetString("JWTToken")))
        {
            return RedirectToAction("Index", "Tasks");
        }
        return RedirectToAction("Login", "Auth");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
