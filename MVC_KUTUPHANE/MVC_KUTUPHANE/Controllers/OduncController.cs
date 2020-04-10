using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KUTUPHANE.Models.Entity;
namespace MVC_KUTUPHANE.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUPHANEEntities db = Tool.GetKUTUPHANEEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET p)
        {
            db.TBL_HAREKET.Add(p);
            db.SaveChanges();
            return View();

        }
    }
}