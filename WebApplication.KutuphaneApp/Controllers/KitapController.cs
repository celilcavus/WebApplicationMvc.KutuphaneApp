using _01_KT.Entity.Entity;
using _01_KT.Entity.View;
using _02_KT.DataModel.Model;
using _03_KT.PresentationLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.KutuphaneApp.Controllers
{
    public class KitapController : Controller
    {
        GenericRepository<Kitap> rep = null;
        AppDbContext db = null;
        public KitapController()
        {
            rep = new GenericRepository<Kitap>();
            db = new AppDbContext();
        }
        private void getList()
        {
            ViewBag.YazarList = new SelectList(db.yazars.ToList(), "Id", "YazarAd");
            ViewBag.TurList = new SelectList(db.Tur.ToList(), "Id", "TurAdi");
        }
        public ActionResult Index()
        {
            getList();
            return View();
        }
        public PartialViewResult PartialViewKitapList()
        {
            var returnList = db.Database.SqlQuery<KitapView>(@"select 
            kt.Id,
            kt.KitapAdi,
            yz.YazarAd,
            t.TurAdi,
            kt.SayfaSayisi,
            kt.Puan
             from Kitaps as kt
            inner join Yazars as yz on yz.Id = kt.YazaId
            inner join Turs as t on t.Id = kt.TurId").ToHashSet();
            if (returnList != null)
            {
                HttpNotFound();
            }
            return PartialView("_PartialViewKitapList", returnList);
        }
        [HttpPost]
        public ActionResult Index(Kitap kitap)
        {
            rep.Insert(kitap);
            getList();
            return View();
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            getList();
            if (id != null)
            {
                var returnId = db.Kitaps.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    
                    return View(returnId);
                }
                else
                    HttpNotFound();
            }
            else
                return HttpNotFound();

            return View();
        }
        [HttpPost]
        public ActionResult Update(int? id,Kitap kitap)
        {
            getList();
            if (id != null)
            {
                var returnId = db.Kitaps.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    returnId.KitapAdi = kitap.KitapAdi;
                    returnId.TurId = kitap.TurId;
                    returnId.YazaId = kitap.YazaId;
                    returnId.SayfaSayisi = kitap.SayfaSayisi;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    HttpNotFound();
            }
            else
                return HttpNotFound();

            return View();
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var returnId = db.Kitaps.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    db.Kitaps.Remove(returnId);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    HttpNotFound();
            }
            else
                return HttpNotFound();

            return View();
        }
    }
}