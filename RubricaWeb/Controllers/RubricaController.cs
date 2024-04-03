using Microsoft.AspNetCore.Mvc;
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
                ImpostaPersona(PK);
            }
            return RedirectToAction("Rubrica", "Home");
        }

        public static void ImpostaPersona(int pk)
        {
            VariabiliGlobali._PersonaAttiva = new();

            foreach (var p in VariabiliGlobali._Rubrica.Persone)
            {
                if (pk == p.PersonaId)
                {
                    VariabiliGlobali._PersonaAttiva.PersonaSingola = p;
                }
            }


            foreach (var r in VariabiliGlobali._Rubrica.Recapiti)
            {
                if (pk == r.PersonaId)
                {
                    VariabiliGlobali._PersonaAttiva.ContattiFiltrati.Add(r);
                }
            }

        }
    }
}
