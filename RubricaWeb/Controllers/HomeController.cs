using System.Diagnostics;
using System.Globalization;
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
        if(VariabiliGlobali._Rubrica.PersonaAttuale == null)
            return View();

        VariabiliGlobali._Rubrica.PersonaAttuale.PK = 0;
        return View();

    }

    public IActionResult Privacy()
    {
        if (VariabiliGlobali._Rubrica.PersonaAttuale == null)
            return View();

        VariabiliGlobali._Rubrica.PersonaAttuale.PK = 0;
        return View();
    }

    public IActionResult Rubrica()
    {
        CaricaFile();

        if (VariabiliGlobali._Rubrica.PersonaAttuale == null || VariabiliGlobali._Rubrica.PersonaAttuale.PK == 0) 
            VariabiliGlobali._Rubrica = new(VariabiliGlobali._ListaPersona, VariabiliGlobali._ListaContatti);
        else
            VariabiliGlobali._Rubrica = new(VariabiliGlobali._ListaPersona, VariabiliGlobali._ListaContatti, VariabiliGlobali._Rubrica.PersonaAttuale);

        return View(VariabiliGlobali._Rubrica);
    }

    public IActionResult MostraContatti(string numero)
    {

        if (numero != null)
        {
            int PK = Convert.ToInt16(numero);
            CaricaFile();
            VariabiliGlobali._Rubrica.PersonaAttuale = new Contatto(PK, VariabiliGlobali._ListaPersona, VariabiliGlobali._ListaContatti);
        }
        return RedirectToAction("Rubrica");
    }

    public void CaricaFile() 
    {
        using (var sr = new StreamReader("Data/Contatti.csv"))
        {
            VariabiliGlobali._ListaContatti.Clear();
            sr.ReadLine();
            while (!sr.EndOfStream)
                VariabiliGlobali._ListaContatti.Add(new Contatti(sr.ReadLine()));
        }

        using (var sr = new StreamReader("Data/Persone.csv"))
        {
            VariabiliGlobali._ListaPersona.Clear();
            sr.ReadLine();
            while (!sr.EndOfStream)
                VariabiliGlobali._ListaPersona.Add(new Persona(sr.ReadLine()));
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
