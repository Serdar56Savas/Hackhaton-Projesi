using OnlineShopping.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShopping.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult cariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cariLogin1(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.cariMail == p.cariMail && x.cariSifre == p.cariSifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.cariMail, false);
                Session["cariMail"] = bilgiler.cariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
           
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();

        }
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x=>x.kullaniciAd==p.kullaniciAd && x.sifre==p.sifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullaniciAd, false);
                Session["kullaniciAd"] = bilgiler.kullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}