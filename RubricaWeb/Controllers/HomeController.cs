using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure;
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
        if(VariabiliGlobali._Rubrica._DBRubrica.PersonaAttuale == null)
            return View();

        VariabiliGlobali._Rubrica._DBRubrica.PersonaAttuale.PK = 0;
        return View();

    }

    public IActionResult Privacy()
    {
        if (VariabiliGlobali._Rubrica._DBRubrica.PersonaAttuale == null)
            return View();

        VariabiliGlobali._Rubrica._DBRubrica.PersonaAttuale.PK = 0;
        return View();
    }

    public IActionResult Rubrica()
    {
        RubricaController.CaricaFile();

        if (VariabiliGlobali._Rubrica._DBRubrica.PersonaAttuale == null || VariabiliGlobali._Rubrica._DBRubrica.PersonaAttuale.PK == 0) 
            VariabiliGlobali._Rubrica._DBRubrica = new(VariabiliGlobali._ListaPersona, VariabiliGlobali._ListaContatti);
        else
            VariabiliGlobali._Rubrica._DBRubrica = new Rubrica(VariabiliGlobali._ListaPersona, VariabiliGlobali._ListaContatti, VariabiliGlobali._Rubrica._DBRubrica.PersonaAttuale);

        return View(VariabiliGlobali._Rubrica);
    }    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
