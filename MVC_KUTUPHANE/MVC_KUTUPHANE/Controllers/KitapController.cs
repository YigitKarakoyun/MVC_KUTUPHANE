using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KUTUPHANE.Models.Entity;
namespace MVC_KUTUPHANE.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var temp = db.TBL_KITAP.ToList();
            return View(temp);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> temp_KategoriListesi = (from i in db.TBL_KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = temp_KategoriListesi;

            List<SelectListItem> temp_YazarListesi = (from i in db.TBL_YAZAR.ToList()
                                                         select new SelectListItem
                                                         {
                                                             Text = i.AD+" "+i.SOYAD,
                                                             Value = i.ID.ToString()
                                                         }).ToList();
            ViewBag.dgr2 = temp_YazarListesi;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBL_KITAP p)
        {
            db.TBL_KITAP.Add(p);
            db.SaveChanges();
            return View();
        }

    }
}