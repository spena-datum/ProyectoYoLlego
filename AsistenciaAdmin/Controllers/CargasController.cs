﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsistenciaAdmin.Models;
using System.IO;
using NPOI.HSSF.UserModel;
using AsistenciaAdmin.Services;

namespace AsistenciaAdmin.Controllers
{
    public class CargasController : Controller
    {
        private string fileSavedPath = "~/";
        private NPServices ServicesNP = new NPServices();
        private AsistenciaAdminContext db = new AsistenciaAdminContext();

        // GET: Cargas
        public ActionResult Index()
        {
            return View(db.Cargas.ToList());
        }

        // GET: Cargas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargas cargas = db.Cargas.Find(id);
            if (cargas == null)
            {
                return HttpNotFound();
            }
            return View(cargas);
        }

        // GET: Cargas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CargaId,UsuarioId,FechaHoraCarga,CodigoMateria,CarnetAlumno,CorreoDocente,CodigoAula,HorarioClase,Dias,Ciclo")] Cargas cargas)
        {
            if (ModelState.IsValid)
            {
                db.Cargas.Add(cargas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargas);
        }

        // GET: Cargas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargas cargas = db.Cargas.Find(id);
            if (cargas == null)
            {
                return HttpNotFound();
            }
            return View(cargas);
        }

        // POST: Cargas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CargaId,UsuarioId,FechaHoraCarga,CodigoMateria,CarnetAlumno,CorreoDocente,CodigoAula,HorarioClase,Dias,Ciclo")] Cargas cargas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargas);
        }

        // GET: Cargas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargas cargas = db.Cargas.Find(id);
            if (cargas == null)
            {
                return HttpNotFound();
            }
            return View(cargas);
        }

        // POST: Cargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargas cargas = db.Cargas.Find(id);
            db.Cargas.Remove(cargas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ImportarExcel(HttpPostedFileBase file)
        {
            string message;
            if (file != null && file.ContentLength > 0 && file.ContentLength < (10 * 1024 * 1024))
            {
                string filetype = file.FileName.Split('.').Last();
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Archivos"), fileName);
                if (filetype == "xls")
                {
                    file.SaveAs(path);
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    HSSFWorkbook excel = new HSSFWorkbook(fs);

                    message = ServicesNP.InsertDataExcel(excel);
                }
                else
                {
                    message = "Formato invalido !";
                }
            }
            else
            {
                message = "Porfavor seleccione un archivo !";
            }
            ViewBag.Message = message;

            return View();
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
