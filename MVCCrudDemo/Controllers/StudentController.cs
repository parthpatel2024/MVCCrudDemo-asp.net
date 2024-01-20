using MVCCrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrudDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly MVCCrudDemoEntities Context = new MVCCrudDemoEntities();
        // GET: Student List
        public ActionResult Index()
        {
            var stud = Context.Students.ToList();
            return View(stud);
        }

        //GET : Student Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student stud)
        {
            if (ModelState.IsValid)
            {
                Context.Students.Add(stud);
                Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET : Student Details
        [HttpGet]
        public ActionResult Details(int id)
        {
            var stud=Context.Students.Where(x => x.Id == id).FirstOrDefault();
            return View(stud);
        }

        // GET : Student Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var stud = Context.Students.Where(x => x.Id == id).FirstOrDefault();
            return View(stud);
        }
        [HttpPost]
        public ActionResult Edit(Student stud)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(stud).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return Edit(stud);
        }

        // GET : Student Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var stud=Context.Students.Where(s=>s.Id == id).FirstOrDefault();
            return View(stud);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var stud = Context.Students.Find(id);
            Context.Students.Remove(stud);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}