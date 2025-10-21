using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Day1.Models;

namespace Day1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public ViewResult Index()
    {
        //string msg = "helloo";
        return View();
    }

    public IActionResult Privacy()
    {
        var task = new TaskItem
        {
            
            Title = "Mvc"
        };

        //var names = new List<string> { "karim", "ahmed", "ali" };
        var names = 1233;


        return View(names);
    }


    public ViewResult About()
    {
        //return View("Index1");


        //View Data

        //var x = 10;
        //x = "ahemd";

        //dynamic x = 10;
        //x = "ahemd";

        //ViewData["Name"] = "Day1 Mvc";
        //ViewData["num"] = x;


        // view bag

        var names = new List<string> { "karim", "ahmed", "ali" };

        ViewData["names"] = names;
        ViewBag.names = names;

        ViewBag.Name = "Karim";



        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
