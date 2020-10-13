using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboration1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Laboration1.Controllers
{
    public class WorkoutplannerController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.text = "Enter your name, the distance and tempo you're planning to run.";
            ViewData["Message"] = "Sida 1 av 4";

            return View();
        }

        [HttpPost]
        public IActionResult Workoutplan(IFormCollection col)
        {
            Workoutplanner workoutplanner = new Workoutplanner();
            workoutplanner.Name = col["Name"];
            workoutplanner.Distance = Convert.ToInt32(col["Distance"]);
            workoutplanner.Tempo = Convert.ToInt32(col["Tempo"]);
            workoutplanner.Calculate();

            string s = JsonConvert.SerializeObject(workoutplanner);
            HttpContext.Session.SetString("workoutsession", s);
            ViewBag.text = "Your workoutplan is as following";
            ViewData["Message"] = "Sida 2 av 4";
            return View(workoutplanner);
        }

        [HttpGet]
        public ActionResult Rating()
        {
            List<SelectListItem> rateworkout = new List<SelectListItem>();
            rateworkout.Add(new SelectListItem { Text = "Too hard, lower distance and pace", Value = "0" });
            rateworkout.Add(new SelectListItem { Text = "Too hard, lower distance", Value = "1" });
            rateworkout.Add(new SelectListItem { Text = "Too hard, lower pace", Value = "2" });
            rateworkout.Add(new SelectListItem { Text = "Ok, just the right distance and pace", Value = "3" });
            rateworkout.Add(new SelectListItem { Text = "To easy, longer distance", Value = "4" });
            rateworkout.Add(new SelectListItem { Text = "To easy, higher pace", Value = "5" });
            rateworkout.Add(new SelectListItem { Text = "To easy, longer distance and higher pace", Value = "6" });
            ViewBag.text = "How would you rate your workoutsession?";
            ViewData["Message"] = "Sida 3 av 4";
            return View(rateworkout);
        }

        [HttpPost]
        public ActionResult Conclusion(IFormCollection col)
        {
            Workoutplanner workoutplanner = new Workoutplanner();
            string s = HttpContext.Session.GetString("workoutsession");
            workoutplanner = JsonConvert.DeserializeObject<Workoutplanner>(s);
            int rating = Convert.ToInt32(col["Rating"]);

            List<SelectListItem> rateworkout = new List<SelectListItem>();
            rateworkout.Add(new SelectListItem { Text = "Too hard, lower distance and pace", Value = "0" });
            rateworkout.Add(new SelectListItem { Text = "Too hard, lower distance", Value = "1" });
            rateworkout.Add(new SelectListItem { Text = "Too hard, lower pace", Value = "2" });
            rateworkout.Add(new SelectListItem { Text = "Ok, just the right distance and pace", Value = "3" });
            rateworkout.Add(new SelectListItem { Text = "To easy, longer distance", Value = "4" });
            rateworkout.Add(new SelectListItem { Text = "To easy, higher pace", Value = "5" });
            rateworkout.Add(new SelectListItem { Text = "To easy, longer distance and higher pace", Value = "6" });

            workoutplanner.Rating = rateworkout[rating].Text;

            s = JsonConvert.SerializeObject(workoutplanner);
            HttpContext.Session.SetString("workoutsession", s);
            ViewBag.text = "Workoutplanner";
            ViewData["Message"] = "Sida 4 av 4";

            return View(workoutplanner);
        }
    }
}
