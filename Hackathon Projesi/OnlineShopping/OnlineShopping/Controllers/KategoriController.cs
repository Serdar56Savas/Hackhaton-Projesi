using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;
namespace OnlineShopping.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        //İndex çalışınca iki metotta çalışacak başta boş olarak eklenecek
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View(); //view yüklenince geti çalıştır
        }
        [HttpPost]
        public ActionResult KategoriEkle(kategori k)
        {
            c.Kategoris.Add(k); //bir butona tıklayınca postu çalıştır
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir",kategori);
        }
        public ActionResult KategoriGuncelle(kategori k)
        {
            var kate = c.Kategoris.Find(k.kategoriID);
            kate.kategoriAd = k.kategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}