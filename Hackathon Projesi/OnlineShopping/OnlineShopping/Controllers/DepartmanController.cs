using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Sınıflar;
namespace OnlineShopping.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult DepartmanEkle()
        {
            return View(); //view yüklenince geti çalıştır
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d); //bir butona tıklayınca postu çalıştır
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var departman = c.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var depp = c.Departmans.Find(d.departmanID);
            depp.departmanAd = d.departmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.personelID == id).ToList();
            var dpt = c.Departmans.Where(x => x.departmanID == id).Select(y => y.departmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.personelid == id).ToList();
            var per = c.Personels.Where(x => x.personelID == id).Select(y => y.personelAd+" "+y.personelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}
