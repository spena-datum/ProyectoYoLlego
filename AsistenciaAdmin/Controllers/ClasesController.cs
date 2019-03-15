using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsistenciaAdmin.Models;

namespace AsistenciaAdmin.Controllers
{
    public class ClasesController : Controller
    {
        private AsistenciaAdminContext db = new AsistenciaAdminContext();

        // GET: Clases
        public ActionResult Index()
        {
            return View(db.Clases.ToList());
        }

        // GET: Clases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clases clases = db.Clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // GET: Clases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClaseId,EstadoClaseId,AulaId,UsuarioId,CargaId,FechaHoraAsistencia,IMEI,Latitud,Longitud,FechaHoraInicio,MateriaId")] Clases clases)
        {
            if (ModelState.IsValid)
            {
                db.Clases.Add(clases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clases);
        }

        // GET: Clases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clases clases = db.Clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // POST: Clases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClaseId,EstadoClaseId,AulaId,UsuarioId,CargaId,FechaHoraAsistencia,IMEI,Latitud,Longitud,FechaHoraInicio,MateriaId")] Clases clases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clases);
        }

        // GET: Clases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clases clases = db.Clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // POST: Clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clases clases = db.Clases.Find(id);
            db.Clases.Remove(clases);
            db.SaveChanges();
            return RedirectToAction("Index");
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
