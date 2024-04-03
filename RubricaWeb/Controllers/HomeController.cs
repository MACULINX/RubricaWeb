using Microsoft.AspNetCore.Mvc;
using RubricaWeb.Models;
using System.Diagnostics;

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
        if (VariabiliGlobali._PersonaAttiva == null)
            return View();

        VariabiliGlobali._PersonaAttiva = null;
        return View();

    }

    public IActionResult Privacy()
    {
        if (VariabiliGlobali._PersonaAttiva == null)
            return View();

        VariabiliGlobali._PersonaAttiva = null;
        return View();
    }

    public IActionResult Rubrica()
    {
        return View(VariabiliGlobali._Rubrica);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
