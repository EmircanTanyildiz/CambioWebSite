using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sonUygulama.Models;
namespace sonUygulama.Controllers
{
    public class KurAlYeniController : Controller
    {
        DBCURRENCYEntities1 db = new DBCURRENCYEntities1();
        // GET: KurAlYeni
        public ActionResult Index()
        {
            var kurlar = db.TBLKITAP.ToList();
            return View(kurlar);
        }
        [HttpGet]
        public ActionResult KurEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KurEkle(TBLKITAP p)
        {
            var ktg = db.TBLKITAP.Where(k=>k.ID== p.ID).FirstOrDefault();
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KurSil(int id)
        {
            var kur = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kur);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
       


    }
}