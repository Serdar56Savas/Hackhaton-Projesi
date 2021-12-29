using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Sınıflar;

namespace OnlineShopping.Controllers
{
    
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View(); //view yüklenince geti çalıştır
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler a)
        {
            a.durum = true;
            c.Carilers.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");
  
        }
        public ActionResult CariSil(int id)
        {
            var car = c.Carilers.Find(id);
            car.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cariler z)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(z.cariID);
            cari.cariAd = z.cariAd;
            cari.cariSoyad = z.cariSoyad;
            cari.cariSehir = z.cariSehir;
            cari.cariMail = z.cariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x=>x.cariid == id).ToList();
            var cr = c.Carilers.Where(x => x.cariID == id).Select(y => y.cariAd + " " + y.cariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }

    }
}