using MVC_KUTUPHANE.Models.Entity;
using System.Linq;
using System.Web.Mvc;
namespace MVC_KUTUPHANE.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var temp = db.TBL_KATEGORI.ToList();
            return View(temp);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TBL_KATEGORI p)
        {
            db.TBL_KATEGORI.Add(p);
            db.SaveChanges();
            return View();
                
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            TBL_KATEGORI p = db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Getir(int id)
        {
            TBL_KATEGORI p = db.TBL_KATEGORI.Find(id);
            return View(p);

        }

        [HttpPost]
        public ActionResult Guncelle(TBL_KATEGORI p)
        {
            TBL_KATEGORI temp = db.TBL_KATEGORI.Find(p.ID);
            temp.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}