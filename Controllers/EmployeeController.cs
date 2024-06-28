using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractice.Models;
using System.Data.Entity;
namespace MVCPractice.Controllers
{
    public class EmployeeController : Controller
    {
        MVC1DBEntities db = new MVC1DBEntities();
        public ActionResult Index()
        {
            List<tblemp> em = db.tblemps.ToList();
            return View(em);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblemp em)
        {
            db.tblemps.Add(em);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) 
        {
            tblemp em = db.tblemps.Find(id);
            return View(em);
        }

        [HttpPost]
        public ActionResult Edit(tblemp em)
        {
            db.Entry<tblemp>(em).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            tblemp em = db.tblemps.Find(id);
            db.tblemps.Remove(em);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        }
}