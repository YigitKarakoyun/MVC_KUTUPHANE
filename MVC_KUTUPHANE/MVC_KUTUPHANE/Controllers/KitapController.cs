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
        DBKUTUPHANEEntities db = Tool.GetKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            //var temp = db.TBL_KITAP.ToList();
            var temp = from k in db.TBL_KITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                temp = temp.Where(m=>m.AD.Contains(p));
            }
            return View(temp.ToList());
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
                                                             Text = i.AD+' '+i.SOYAD,
                                                             Value = i.ID.ToString()
                                                         }).ToList();
            ViewBag.dgr2 = temp_YazarListesi;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBL_KITAP p)
        {
            var kategori = db.TBL_KATEGORI.Where(k=>k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var yazar = db.TBL_YAZAR.Where(y=>y.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            p.TBL_KATEGORI = kategori;
            p.TBL_YAZAR = yazar;
            db.TBL_KITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var temp = db.TBL_KITAP.Find(id);
            db.TBL_KITAP.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Getir(int id)
        {
            var p = db.TBL_KITAP.Find(id);
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
                                                          Text = i.AD + ' ' + i.SOYAD,
                                                          Value = i.ID.ToString()
                                                      }).ToList();
            ViewBag.dgr2 = temp_YazarListesi;
            return View(p);

        }
        [HttpPost]
        public ActionResult Guncelle(TBL_KITAP p)
        {
            var temp = db.TBL_KITAP.Find(p.ID);
            temp.AD = p.AD;
            temp.KATEGORI = p.KATEGORI;
            temp.YAZAR = p.YAZAR;
            temp.BASIMYIL = p.BASIMYIL;
            temp.YAYINEVI = p.YAYINEVI;
            temp.SAYFA = p.SAYFA;
            temp.DURUM = p.DURUM;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}