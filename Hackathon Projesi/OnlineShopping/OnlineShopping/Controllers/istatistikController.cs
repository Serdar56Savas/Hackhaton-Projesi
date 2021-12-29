using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Sınıflar;
namespace OnlineShopping.Controllers
{
    public class istatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Sum(x=>x.stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Uruns select x.marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Count(x => x.stok <=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.satisFiyat descending select x.urunAd ).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Uruns orderby x.satisFiyat ascending select x.urunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.Count(x => x.urunAd=="Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Count(x => x.urunAd == "Leptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Uruns.GroupBy(x => x.marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.Uruns.Where(u => u.urunID == (c.SatisHarekets.GroupBy(x => x.urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.urunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.tarih == bugun).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SatisHarekets.Where(x => x.tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
            
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.cariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.departmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                         group x by x.marka into g
                         select new SinifGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }
    }
}