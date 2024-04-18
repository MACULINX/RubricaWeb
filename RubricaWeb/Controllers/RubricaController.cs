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

            ResetPagina();

            return RedirectToAction("Rubrica", "Home");
        }

        public IActionResult MostraAggiungiContatto()
        {
            ResetPagina();

            VariabiliGlobali._Aggiungi = true;

            return RedirectToAction("Rubrica", "Home");
        }

        public IActionResult RimuoviContatto(int SelezioneContatto)
        {
            Rubrica.RimuoviPersona(SelezioneContatto);

            ResetPagina();

            return RedirectToAction("Rubrica", "Home");
        }

        public IActionResult MostraRimuoviContatto()
        {
            ResetPagina();

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

        public void ResetPagina() 
        {
            VariabiliGlobali._Rimuovi = false;
            VariabiliGlobali._Aggiungi = false;
            VariabiliGlobali._PersonaAttiva = null;
        }
    }
}
