using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RubricaWeb.Models;

namespace RubricaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<string> s = new List<string>();

        using( var sr = new StreamReader("Data/Contatti.csv"))
        {
            while(!sr.EndOfStream)
                s.Add(sr.ReadLine());
        }
        return View(s);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Rubrica()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
