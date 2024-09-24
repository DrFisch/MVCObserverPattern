using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using MVCObserverPattern.Models;

namespace MVCObserverPattern.Controllers
{
    public class ProduktController : Controller
    {
        private static ProduktManager produktManager = new ProduktManager();

        public IActionResult Index()
        {
            return View(produktManager.Produkte);
        }

        [HttpPost]
        public IActionResult Aktualisieren(string name, decimal preis, int lagerbestand)
        {
            produktManager.AktualisiereProdukt(name, preis, lagerbestand);
            return RedirectToAction("Index");
        }
    }
}
