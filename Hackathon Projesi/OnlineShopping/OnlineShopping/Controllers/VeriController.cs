using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Sınıflar;

namespace OnlineShopping.Controllers
{
    public class VeriController : Controller
    {
        // GET: Veri

        SqlCommand com = new SqlCommand();
        SqlDataReader dataReader;
        SqlConnection con = new SqlConnection("data source=LAPTOP-7M06I3FK\\SQLEXPRESS;initial catalog=dbTicarii;integrated security=True;");

        List<Faturalar> faturalars = new List<Faturalar>();
        List<Personel> personels = new List<Personel>();
        List<Urun> uruns = new List<Urun>();


        public ActionResult Index()
        {
            FetchData();
            return View(faturalars);
        }
        private void FetchData()
        {

            try
            {
                con.Open();
                com.Connection = con;

                com.CommandText = "SELECT * FROM View_1";
                dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    faturalars.Add(new Faturalar()
                    {

                        faturaSeriNo = dataReader["faturaSeriNo"].ToString()
                    ,
                        tarih = Convert.ToDateTime(dataReader["tarih"])
                    ,
                        saat = dataReader["saat"].ToString()
                    ,
                        teslimAlan = dataReader["teslimAlan"].ToString()
                    ,
                        teslimEden = dataReader["teslimEden"].ToString()
                    ,
                        Toplam = Convert.ToDecimal(dataReader["Toplam"])

                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Yeni()
        {
            FetchData1();
            return View(personels);
        }
        private void FetchData1()
        {

            try
            {
                con.Open();
                com.Connection = con;

                com.CommandText = "SELECT * FROM View_2";
                dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    personels.Add(new Personel()
                    {

                        personelAd = dataReader["personelAd"].ToString()
                    ,
                        personelSoyad = dataReader["personelSoyad"].ToString()
                    ,
                        Departmanid = Convert.ToInt32(dataReader["departmanId"])

                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Yeni2()
        {
            FetchData2();
            return View(uruns);
        }
        private void FetchData2()
        {

            try
            {
                con.Open();
                com.Connection = con;

                com.CommandText = "SELECT * FROM View_3";
                dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    uruns.Add(new Urun()
                    {

                        urunAd = dataReader["urunAd"].ToString()
                    ,
                        marka = dataReader["marka"].ToString()
                    ,
                        stok = Convert.ToInt16(dataReader["stok"])
                    ,
                        alisFiyat = Convert.ToDecimal(dataReader["alisFiyat"])
                    ,
                        satisFiyat = Convert.ToDecimal(dataReader["satisFiyat"])
                    ,
                        kategoriid = Convert.ToInt32(dataReader["kategoriID"])

                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}