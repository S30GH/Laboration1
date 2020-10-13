using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo3_1.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Demo3_1.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            ViewData["Message"] = "Detta är starttext som flyttas med ViewData.";
            ViewBag.text = "Detta är text via ViewBag.";
            string s = "Text i en sessionvariabel.";
            HttpContext.Session.SetString("test", s);
            return View();
        }

        public IActionResult Index2()
        {
            string s2 = HttpContext.Session.GetString("test");
            ViewBag.text = s2;
            return View();

        }

        public IActionResult Index3()
        {
            Item myitem = new Item();
            myitem.Name = "Ann Andersson";
            string s1 = JsonConvert.SerializeObject(myitem);
            //test1 är sessionsvariabeln
            HttpContext.Session.SetString("test1", s1);
            ViewBag.jsonstring = s1;
            return View(myitem);
        }

        public IActionResult Index4()
        {
            string s2 = HttpContext.Session.GetString("test1");
            Item myitem2 = JsonConvert.DeserializeObject<Item>(s2);
            return View(myitem2);
            
            //Kommenterat bort allt som tidigare var i Index4
            //Item myItem = new Item();
            //return View(myItem);
        }

        public IActionResult Index5()
        {
            var itemlist = new List<Item>();
            itemlist.Add(new Item() { Id = 1, Name = "Olle" });
            itemlist.Add(new Item() { Id = 2, Name = "Anna" });
            string s = JsonConvert.SerializeObject(itemlist);
            HttpContext.Session.SetString("test5", s);
            ViewBag.jsonstring = s;

            return View(itemlist);
        }

        public IActionResult Index6()
        {
            var itemlist = new List<Item>();
            string s = HttpContext.Session.GetString("test5");
            if ((s != null) || (s == ""))
            {
                itemlist = JsonConvert.DeserializeObject<List<Item>>(s);
            }
            
            return View(itemlist);
        }

        [HttpGet]
        public IActionResult Form1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form1(IFormCollection fc)
        {
            string s = fc["textexempel"];
            ViewBag.s = s;
            return View();
        }

        [HttpGet]
        public IActionResult Form2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form2(IFormCollection fc)
        {
            string s = fc["textexempel"];
            ViewBag.s = s;
            return View();
        }

        [HttpGet]
        public IActionResult Form3()
        {
            return View();
        }

        [HttpGet]
        //textexempel måste vara samma som från Form3.cshtml
        public IActionResult Form4([FromQuery]string textexempel)
        {
            ViewBag.s = textexempel;
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Index7()
        {

            //fixa till ViewData
            List<Person> personer = new List<Person>
            {
                new Person {Id = 1, Namn = "Olle Olofsson"},
                new Person {Id = 2, Namn = "Anna Olofsson"},
                new Person {Id = 3, Namn = "Annika Rutberg"},
                new Person {Id = 4, Namn = "Nils Nilsson"},

            };

            ViewData["personer_i_lista"] = personer;

            //fixa till ViewBag
            List<Person> personer2 = new List<Person>
            {
                new Person(1, "Anna tvåan Olofsson"),
                new Person(2, "Olga tvåan Eriksson"),
                new Person(3, "Annika tvåan Rutberg"),
                new Person(4, "Nils tvåan Nilsson"),
                new Person(5, "Alf Tollefssen")
            };

            ViewBag.personer = personer2;


            List<Person> personer3 = new List<Person>
            {
                new Person(1, "Anna trean Olofsson"),
                new Person(2, "Olga trean Eriksson"),
                new Person(3, "Annika trean Rutberg"),
                new Person(4, "Stefan trean Berglund")

            };

            ViewModeln vm = new ViewModeln
            {
                PersonDetaljLista = personer3
            };

            return View(vm);
        }

        public ActionResult Index8()
        {
            List<Person> personer = new List<Person>
            {
                new Person(1, "Anna fyran Olofsson"),
                new Person(2, "Olga fyran Eriksson"),
                new Person(3, "Annika fyran Rutberg"),
                new Person(4, "Stefan fyran Berglund")
            };
            return View(personer);
        }
    }
}
