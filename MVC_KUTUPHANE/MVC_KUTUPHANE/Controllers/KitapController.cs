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
    }
}