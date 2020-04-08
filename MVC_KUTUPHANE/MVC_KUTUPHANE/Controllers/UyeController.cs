using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KUTUPHANE.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MVC_KUTUPHANE.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = Tool.GetKUTUPHANEEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var temp = db.TBL_UYELER.ToList();
            var temp = db.TBL_UYELER.ToList().ToPagedList(sayfa, 3);
            return View(temp);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            var p = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Getir(int id)
        {
            var p = db.TBL_UYELER.Find(id);
            return View(p);

        }

        [HttpPost]
        public ActionResult Guncelle(TBL_UYELER p)
        {
            var temp = db.TBL_UYELER.Find(p.ID);
            temp.AD = p.AD;
            temp.SOYAD = p.SOYAD;
            temp.MAIL = p.MAIL;
            temp.KULLANICIADI = p.KULLANICIADI;
            temp.SIFRE = p.SIFRE;
            temp.OKUL = p.OKUL;
            temp.TELEFON = p.TELEFON;
            temp.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}