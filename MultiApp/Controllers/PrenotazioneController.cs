using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MultiApp.Models;
using System.Linq;

namespace MultiApp.Controllers
{
    public class PrenotazioneController : Controller
    {
        private static List<Sala> sale = new List<Sala>
{
    new Sala("Sala 1", 50, 20, 120),
    new Sala("Sala 2", 30, 10, 120),
    new Sala("Sala 3", 40, 15, 120)
};


        private static List<Prenotazione> prenotazioni = new List<Prenotazione>();

        public IActionResult Index()
        {
            return View(sale); 
        }

        [HttpPost]
        public IActionResult Prenota(string nome, string cognome, string sala, string tipoBiglietto)
        {
            var salaSelezionata = sale.FirstOrDefault(s => s.Nome == sala);
            if (salaSelezionata == null || salaSelezionata.BigliettiVenduti >= salaSelezionata.CapienzaMassima)
            {
                return BadRequest("La sala selezionata è piena o non esiste.");
            }

            prenotazioni.Add(new Prenotazione
            {
                Nome = nome,
                Cognome = cognome,
                Sala = sala,
                TipoBiglietto = tipoBiglietto
            });
            

            salaSelezionata.BigliettiVenduti++;
            if (tipoBiglietto == "ridotto")
            {
                salaSelezionata.BigliettiRidottiVenduti++;
            }

            return RedirectToAction("Index");
        }
    }
}







