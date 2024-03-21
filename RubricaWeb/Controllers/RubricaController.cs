using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RubricaWeb.Models;

namespace RubricaWeb.Controllers
{
    public class RubricaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostraContatti(string numero)
        {

            if (numero != null)
            {
                int PK = Convert.ToInt16(numero);
                CaricaFile();
                VariabiliGlobali._Rubrica.PersonaAttuale = new Contatto(PK, VariabiliGlobali._ListaPersona, VariabiliGlobali._ListaContatti);
            }
            return RedirectToAction("Rubrica","Home");
        }

        public static void CaricaFile()
        {
            VariabiliGlobali._ListaContatti = new ListRecapito("Data/Contatti.csv");

            VariabiliGlobali._ListaPersona = new ListPersona("Data/Persone.csv");
        }
    }
}
