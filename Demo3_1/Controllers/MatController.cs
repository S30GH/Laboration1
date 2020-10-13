using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo3_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Demo3_1.Controllers
{
    public class MatController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Recept(IFormCollection col)
        {
            Middag m = new Middag();
            m.Namn = col["Namn"];
            m.AntalPotioner = Convert.ToInt32(col["AntalPotioner"]);
            m.Datum = Convert.ToDateTime(col["Datum"]);
            m.Berakna();
            string s = JsonConvert.SerializeObject(m);
            HttpContext.Session.SetString("matsession", s);
            return View(m);
        }

        [HttpGet]
        public ActionResult Betyg()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            //Skapa en lista med betyg
            lista.Add(new SelectListItem { Text = "Uruselt", Value = "0" });
            lista.Add(new SelectListItem { Text = "Uselt", Value = "1" });
            lista.Add(new SelectListItem { Text = "Dåligt", Value = "2" });
            lista.Add(new SelectListItem { Text = "Normalt", Value = "3" });
            lista.Add(new SelectListItem { Text = "Bättre än normalt", Value = "4" });
            lista.Add(new SelectListItem { Text = "Gott", Value = "5" });
            lista.Add(new SelectListItem { Text = "Absolut toppen", Value = "6" });

            return View(lista);
        }

        [HttpPost]
        public ActionResult Slutsats(IFormCollection col)
        {
            Middag m = new Middag();
            string s = HttpContext.Session.GetString("matsession");
            m = JsonConvert.DeserializeObject<Middag>(s);
            int betyg = Convert.ToInt32(col["Betyg"]);

            List<SelectListItem> lista = new List<SelectListItem>();
            //Skapa en lista med betyg
            lista.Add(new SelectListItem { Text = "Uruselt", Value = "0" });
            lista.Add(new SelectListItem { Text = "Uselt", Value = "1" });
            lista.Add(new SelectListItem { Text = "Dåligt", Value = "2" });
            lista.Add(new SelectListItem { Text = "Normalt", Value = "3" });
            lista.Add(new SelectListItem { Text = "Bättre än normalt", Value = "4" });
            lista.Add(new SelectListItem { Text = "Gott", Value = "5" });
            lista.Add(new SelectListItem { Text = "Absolut toppen", Value = "6" });

            m.Betyg = lista[betyg].Text;

            s = JsonConvert.SerializeObject(m);
            HttpContext.Session.SetString("matsession", s);

            return View(m);
        }
[HttpGet]
        public IActionResult Alternativ()
        {
            Middag m = new Middag();
            string s = HttpContext.Session.GetString("matsession");
            m = JsonConvert.DeserializeObject<Middag>(s);
            
            return View(m);
        }
    }
}
