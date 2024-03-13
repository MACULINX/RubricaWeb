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
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Rubrica()
    {
        ListContatti lc = new();

        using (var sr = new StreamReader("Data/Contatti.csv"))
        {
            while (!sr.EndOfStream)
                lc.Add(new Contatti(sr.ReadLine()));
        }

        ListPersona lp = new();
        using (var sr = new StreamReader("Data/Persone.csv"))
        {
            while (!sr.EndOfStream)
                lp.Add(new Persona(sr.ReadLine()));
        }

        Rubrica r = new(lp, lc);

        return View(r);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
