using Microsoft.AspNetCore.Mvc;
using RubricaWeb.Models;

namespace RubricaWeb.Controllers
{
    public class RubricaController : Controller
    {
        public Db Rubrica { get; set; }

        public RubricaController() 
        { 
            Rubrica = new();
        }

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

        public IActionResult AggiungiContatto(Persona p)
        {
            Rubrica.AggiungiPersona(p);

            VariabiliGlobali._Aggiungi = false;

            return RedirectToAction("Rubrica", "Home");
        }

        public IActionResult MostraAggiungiContatto()
        {
            VariabiliGlobali._Aggiungi = true;

            return RedirectToAction("Rubrica", "Home");
        }

        public IActionResult RimuoviContatto(int SelezioneContatto)
        {
            Rubrica.RimuoviPersona(SelezioneContatto);

            VariabiliGlobali._Rimuovi = false;

            return RedirectToAction("Rubrica", "Home");
        }

        public IActionResult MostraRimuoviContatto()
        {
            VariabiliGlobali._Rimuovi = true;

            return RedirectToAction("Rubrica", "Home");
        }

        public void ImpostaPersona(int pk)
        {
            VariabiliGlobali._PersonaAttiva = new();

            foreach (var p in Rubrica.Persone)
                if (pk == p.PersonaId)
                    VariabiliGlobali._PersonaAttiva.PersonaSingola = p;

            foreach (var r in Rubrica.Recapiti)
                if (pk == r.PersonaId)
                    VariabiliGlobali._PersonaAttiva.ContattiFiltrati.Add(r);
        }

    }
}
