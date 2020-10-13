using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo3_1.Models;
using Microsoft.AspNetCore.Http;

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
            Item myItem = new Item();
            return View(myItem);
        }

        public IActionResult Index4()
        {
            Item myItem = new Item();
            return View(myItem);
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
    }
}
