namespace AsistenciaAdmin.Controllers
{
    using AsistenciaAdmin.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class EstadosClaseController : Controller
    {
        private AsistenciaAdminContext db = new AsistenciaAdminContext();

        // GET: EstadosClase
        public ActionResult Index()
        {
            return View(db.EstadosClase.ToList());
        }

        // GET: EstadosClase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadosClase estadosClase = db.EstadosClase.Find(id);
            if (estadosClase == null)
            {
                return HttpNotFound();
            }
            return View(estadosClase);
        }

        // GET: EstadosClase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadosClase/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoClaseId,Estado")] EstadosClase estadosClase)
        {
            if (ModelState.IsValid)
            {
                db.EstadosClase.Add(estadosClase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadosClase);
        }

        // GET: EstadosClase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadosClase estadosClase = db.EstadosClase.Find(id);
            if (estadosClase == null)
            {
                return HttpNotFound();
            }
            return View(estadosClase);
        }

        // POST: EstadosClase/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoClaseId,Estado")] EstadosClase estadosClase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadosClase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadosClase);
        }

        // GET: EstadosClase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadosClase estadosClase = db.EstadosClase.Find(id);
            if (estadosClase == null)
            {
                return HttpNotFound();
            }
            return View(estadosClase);
        }

        // POST: EstadosClase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadosClase estadosClase = db.EstadosClase.Find(id);
            db.EstadosClase.Remove(estadosClase);
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
