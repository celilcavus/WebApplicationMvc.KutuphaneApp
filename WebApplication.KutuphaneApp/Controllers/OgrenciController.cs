using _01_KT.Entity.Entity;
using _02_KT.DataModel.Model;
using _03_KT.PresentationLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.KutuphaneApp.Controllers
{
    public class OgrenciController : Controller
    {
        GenericRepository<Ogrenci> ogr = null;
        AppDbContext db = null;
        public OgrenciController()
        {
            ogr = new GenericRepository<Ogrenci>();
            db = new AppDbContext();
        }

      
        public ActionResult Index()
        {
           
            return View();
        }
        public PartialViewResult PartialOgrenciList()
        {
            var returnOgrList = ogr.List();
            return PartialView("_PartialPageOgrenciToList", returnOgrList);
        }


        public ActionResult Insert()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Insert(Ogrenci ogrenci)
        {
            ogr.Insert(ogrenci);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {

            if (id != null)
            {
                var returnVal = db.Ogrenci.Where(x => x.Id == id).FirstOrDefault();
                if (returnVal != null)
                {
                   
                    return View(returnVal);
                }
                else
                    HttpNotFound();
            }
            else
                HttpNotFound();
            return View();
        }
        [HttpPost]
        public ActionResult Update(int? id, Ogrenci ogrenci)
        {

            if (id != null)
            {
                var returnId = db.Ogrenci.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    returnId.OgrenciAd = ogrenci.OgrenciAd;
                    returnId.OgrenciSoyad = ogrenci.OgrenciSoyad;
                    returnId.Cinsiyet = ogrenci.Cinsiyet;
                    returnId.DogumTarih = ogrenci.DogumTarih;
                    returnId.Sinif = ogrenci.Sinif;
                    returnId.Puan = ogrenci.Puan;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id != null)
            {
                Ogrenci returnVal = db.Ogrenci.Where(x => x.Id == id).FirstOrDefault();
                if (returnVal != null)
                {
                    db.Ogrenci.Remove(returnVal);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    HttpNotFound();
            }
            else
                HttpNotFound();
            return View();
        }
    }
}