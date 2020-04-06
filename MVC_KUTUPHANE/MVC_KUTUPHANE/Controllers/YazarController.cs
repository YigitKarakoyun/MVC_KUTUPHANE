using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KUTUPHANE.Models.Entity;
namespace MVC_KUTUPHANE.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var temp = db.TBL_YAZAR.ToList();
            return View(temp);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBL_YAZAR p)
        {
            db.TBL_YAZAR.Add(p);
            db.SaveChanges();
            return View();
        }
      
        public ActionResult Sil(int id)
        {
            var temp = db.TBL_YAZAR.Find(id);
            db.TBL_YAZAR.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Getir(int id)
        {
            var p = db.TBL_YAZAR.Find(id);
            return View(p);

        }

        [HttpPost]
        public ActionResult Guncelle(TBL_YAZAR p)
        {
            var temp = db.TBL_YAZAR.Find(p.ID);
            temp.AD = p.AD;
            temp.DETAY = p.DETAY;
            temp.SOYAD = p.SOYAD;
          
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}