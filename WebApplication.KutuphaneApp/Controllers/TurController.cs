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
    public class TurController : Controller
    {
        AppDbContext db = null;
        GenericRepository<Tur> rep = null;
        public TurController()
        {
            db = new AppDbContext();
            rep = new GenericRepository<Tur>();
        }
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult PartialViewTurToList()
        {
            return PartialView("_PartialViewTurToList", rep.List());
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Insert(Tur tur)
        {
            rep.Insert(tur);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id != null)
            {
                var returnId = db.Tur.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    return View(returnId);
                }
                else
                    return HttpNotFound();
            }
            else
                HttpNotFound();
            return View();
        }
        [HttpPost]
        public ActionResult Update(int? id, Tur tur)
        {
            if (id != null)
            {
                var returnId = db.Tur.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    returnId.TurAdi = tur.TurAdi;
                    db.SaveChanges();
                    return View();
                }
                else
                    return HttpNotFound();
            }
            else
                HttpNotFound();
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var returnId = db.Tur.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    db.Tur.Remove(returnId);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
                return HttpNotFound();
            return RedirectToAction("Index");
        }
    }
}