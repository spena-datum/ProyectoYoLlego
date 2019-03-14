namespace AsistenciaAdmin.Controllers
{
    using AsistenciaAdmin.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class MateriasController : Controller
    {
        private AsistenciaAdminContext db = new AsistenciaAdminContext();

        // GET: Materias
        public ActionResult Index()
        {
            return View(db.Materias.ToList());
        }

        // GET: Materias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materias materias = db.Materias.Find(id);
            if (materias == null)
            {
                return HttpNotFound();
            }
            return View(materias);
        }

        // GET: Materias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MateriaId,Codigo,Nombre,Facultad")] Materias materias)
        {
            if (ModelState.IsValid)
            {
                db.Materias.Add(materias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materias);
        }

        // GET: Materias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materias materias = db.Materias.Find(id);
            if (materias == null)
            {
                return HttpNotFound();
            }
            return View(materias);
        }

        // POST: Materias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MateriaId,Codigo,Nombre,Facultad")] Materias materias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materias);
        }

        // GET: Materias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materias materias = db.Materias.Find(id);
            if (materias == null)
            {
                return HttpNotFound();
            }
            return View(materias);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materias materias = db.Materias.Find(id);
            db.Materias.Remove(materias);
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
