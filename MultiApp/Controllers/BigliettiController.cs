
namespace MultiApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq; 


        public class BigliettiController : Controller
        {
            private static List<Sala> sale = new List<Sala>
        {
            new Sala { Nome = "Sala 1", BigliettiVenduti = 10, CapienzaMassima = 100, BigliettiRidottiVenduti = 2 },
            new Sala { Nome = "Sala 2", BigliettiVenduti = 30, CapienzaMassima = 200, BigliettiRidottiVenduti = 5 },
            new Sala { Nome = "Sala 3", BigliettiVenduti = 50, CapienzaMassima = 300, BigliettiRidottiVenduti = 8 },
        };

            public IActionResult Index()
            {
                return View(sale);
            }

            [HttpPost]
            public IActionResult AggiungiBiglietto(string sala)
            {
                var salaSelezionata = sale.FirstOrDefault(s => s.Nome == sala);
                if (salaSelezionata != null && salaSelezionata.BigliettiVenduti < salaSelezionata.CapienzaMassima)
                {
                    salaSelezionata.BigliettiVenduti++;
                }
                return RedirectToAction("Index");
            }

            [HttpPost]
            public IActionResult RimuoviBiglietto(string sala)
            {
                var salaSelezionata = sale.FirstOrDefault(s => s.Nome == sala);
                if (salaSelezionata != null && salaSelezionata.BigliettiVenduti > 0)
                {
                    salaSelezionata.BigliettiVenduti--;
                }
                return RedirectToAction("Index");
            }
        }


        public class Sala
        {
            public required string Nome { get; set; }
            public int BigliettiVenduti { get; set; }
            public int CapienzaMassima { get; set; }
            public int BigliettiRidottiVenduti { get; set; }
        }
        
    }



