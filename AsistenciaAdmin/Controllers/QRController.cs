namespace AsistenciaAdmin.Controllers
{
    using System.Data.Entity;
    using System.Drawing;
    using System.IO;
    using System.Web.Mvc;
    using Models;
    using QRCoder;

    public class QRController : Controller
    {
        private AsistenciaAdminContext db = new AsistenciaAdminContext();
        // GET: QR
        public ActionResult Index(int? AulaId)
        {
            var aula = db.Aulas.Find(AulaId).NombreAula;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(aula, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ViewBag.imageBytes = ms.ToArray();
                    //imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
            }
            return View(ViewBag);
        }
    }
}