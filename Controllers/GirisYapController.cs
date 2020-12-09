using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVLingtoSQL.Models.Entity;
using System.Web.Security;

namespace CVLingtoSQL.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        public ActionResult Index()
        {
            return View();
        }
        DBCVEntityEntities db = new DBCVEntityEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var bilgi = db.Admins.FirstOrDefault
                (x => x.KullaniciAdi == ad.KullaniciAdi && x.Sifre == ad.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.mesaj = "UserName or Password wrong!";
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Default");
        }
    }
}