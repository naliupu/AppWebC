using AppWebC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebC.Controllers
{
    [Authorize]
    public class ColorController : Controller
    {
        // GET: Color
        public ActionResult Index()
        {
            List<Color> colores = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                colores = db.Color.ToList();
            }

            return View(colores);
        }

        // GET: Color/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Color/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Color/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre_color, color")] Color colores)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View(colores);
                }

                try
                {
                    db.Color.Add(colores);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(colores);
                }
            }
        }

        // GET: Color/Edit/5
        public ActionResult Edit(int id)
        {

            if (id < 0)
            {
                return RedirectToAction("Index");
            }

            Color color = null;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                color = db.Color.Find(id);
            }
            return View(color);
        }

        // POST: Color/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id, nombre_color, color")] Color colores)
        {
            if (!ModelState.IsValid)
            {
                return View(colores);
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(colores).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
