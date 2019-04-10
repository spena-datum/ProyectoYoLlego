namespace AsistenciaAdmin.Controllers
{
    using AsistenciaAdmin.Models;
    using QRCoder;
    using System.Data.Entity;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class AulasController : Controller
    {
        private AsistenciaAdminContext db = new AsistenciaAdminContext();

        // GET: Aula
        public ActionResult Index()
        {
            return View(db.Aulas.ToList());
        }

        // GET: Aula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aulas aula = db.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // GET: Aula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AulaId,NombreAula")] Aulas aula)
        {
            if (ModelState.IsValid)
            {
                db.Aulas.Add(aula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aula);
        }

        // GET: Aula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aulas aula = db.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // POST: Aula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AulaId,NombreAula")] Aulas aula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aula);
        }

        // GET: Aula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aulas aula = db.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // POST: Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aulas aula = db.Aulas.Find(id);
            db.Aulas.Remove(aula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GenerarQR(int? AulaId)
        {
            if (AulaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aulas aula = db.Aulas.Find(AulaId);
            if (aula == null)
            {
                return HttpNotFound();
            }

            var nombreAula = db.Aulas.Find(AulaId).NombreAula;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(nombreAula, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    QR newQR = new QR();

                    ViewBag.imageBytes = ms.ToArray();
                    //imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
            }
            return View(ViewBag);
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
