using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo3_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Demo3_1.Controllers
{
    public class NewItemController : Controller
    {
        // GET: NewItemController
        public ActionResult Index()
        {
            Item item = new Item();
            string s = HttpContext.Session.GetString("test");
            item = JsonConvert.DeserializeObject<Item>(s);
            ViewBag.Id = item.Id;
            ViewBag.Name = item.Name;

            return View();
        }

        // GET: NewItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var item = new Item();
                item.Name = collection["Name"];
                item.Id = Convert.ToInt32(collection["Id"]);
                string s = JsonConvert.SerializeObject(item);
                HttpContext.Session.SetString("test", s);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
