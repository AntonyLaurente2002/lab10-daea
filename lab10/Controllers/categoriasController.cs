using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab10.Models;

namespace lab10.Controllers
{
    public class categoriasController : Controller
    {
        private NeptunoDBEntities1 db = new NeptunoDBEntities1();

        // GET: categorias
        public ActionResult Index()
        {
            return View(db.categorias.ToList());
        }

        // GET: categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorias categorias = db.categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // GET: categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcategoria,nombrecategoria,descripcion,Activo,CodCategoria")] categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.categorias.Add(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorias);
        }

        // GET: categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorias categorias = db.categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcategoria,nombrecategoria,descripcion,Activo,CodCategoria")] categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorias);
        }

        // GET: categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorias categorias = db.categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                categorias categorias = db.categorias.Find(id);
                db.categorias.Remove(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Registrar detalles de la excepción para facilitar la depuración
                var errorMessage = $"Exception: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $" Inner Exception: {ex.InnerException.Message}";
                    if (ex.InnerException.InnerException != null)
                    {
                        errorMessage += $" Inner Inner Exception: {ex.InnerException.InnerException.Message}";
                    }
                }
                // Registrar la excepción en los registros de eventos o en un archivo de registro
                System.Diagnostics.Debug.WriteLine(errorMessage);

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, errorMessage);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
