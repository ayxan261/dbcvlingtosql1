using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVLingtoSQL.Models.Entity;

namespace CVLingtoSQL.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DBCVEntityEntities db = new DBCVEntityEntities();
        public ActionResult Index()
        {
            var about = db.Hakkimdas.ToList();
            return View(about);
        }
        public PartialViewResult Education()
        {
            var educate = db.Hakkimdas.ToList();
            return PartialView(educate);
        }

        public PartialViewResult Experience()
        {
            var exp = db.Hakkimdas.ToList();
            return PartialView(exp);
        }
        public PartialViewResult Skills()
        {
            var skii = db.Yeteneklers.ToList();
            return PartialView(skii);
        }

        public PartialViewResult Contact()
        {
            
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(Ilestisim ile)
        {
            db.Ilestisims.Add(ile);
            db.SaveChanges();
            return PartialView();
        }
    }
}