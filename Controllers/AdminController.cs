using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVLingtoSQL.Models.Entity;

namespace CVLingtoSQL.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DBCVEntityEntities db = new DBCVEntityEntities();

        [Authorize]
        public ActionResult Index()
        {
            var yetenek = db.Yeteneklers.ToList();
            return View(yetenek);
        }

        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(Yetenekler ytn)
        {
            db.Yeteneklers.Add(ytn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            Yetenekler ytn = db.Yeteneklers.Find(id);
            db.Yeteneklers.Remove(ytn);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult YetenekGetir(int id)
        {
            var deger = db.Yeteneklers.Find(id);
            return View("YetenekGetir", deger);
        }

        public ActionResult Guncelle (Yetenekler yet)
        {
            var deger = db.Yeteneklers.Find(yet.Id);
            deger.Yetenek = yet.Yetenek;
            deger.Derece = yet.Derece;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Contact()
        {
            var deg = db.Ilestisims.ToList();
            return View(deg);
        }

        public  ActionResult ContactSil(int id)
        {
            Ilestisim cont = db.Ilestisims.Find(id);
            db.Ilestisims.Remove(cont);
            db.SaveChanges();
            return RedirectToAction("Contact");

        }
        public ActionResult MesajGoster(int id)
        {
            var m = db.Ilestisims.Find(id);
            return View("MesajGoster", m);
        }

        public ActionResult Static()
        {
            ViewBag.deger = db.Yeteneklers.Max(x => x.Yetenek).ToString();
            var ski = db.Yeteneklers.ToList();
            return View(ski);
        }

    }
}