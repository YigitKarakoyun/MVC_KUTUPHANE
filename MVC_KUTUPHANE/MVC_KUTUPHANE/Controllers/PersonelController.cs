using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KUTUPHANE.Controllers;
using MVC_KUTUPHANE.Models.Entity;

namespace MVC_KUTUPHANE.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities db = Tool.GetKUTUPHANEEntities();
        public ActionResult Index()
        {
            var temp = db.TBL_PERSONEL.ToList();
            return View(temp);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TBL_PERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.TBL_PERSONEL.Add(p);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            var p = db.TBL_PERSONEL.Find(id);
            db.TBL_PERSONEL.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Getir(int id)
        {
            var p = db.TBL_PERSONEL.Find(id);
            return View(p);

        }

        [HttpPost]
        public ActionResult Guncelle(TBL_PERSONEL p)
        {
            var temp = db.TBL_PERSONEL.Find(p.ID);
            temp.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}