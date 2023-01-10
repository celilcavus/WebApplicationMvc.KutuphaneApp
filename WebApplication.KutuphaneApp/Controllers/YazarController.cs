using _01_KT.Entity.Entity;
using _02_KT.DataModel.Model;
using _03_KT.PresentationLayer.Repository;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication.KutuphaneApp.Controllers
{
    public class YazarController : Controller
    {
        AppDbContext db = null;
        GenericRepository<Yazar> rep = null;
        public YazarController()
        {
            rep = new GenericRepository<Yazar>();
            db = new AppDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialViewToYazarList()
        {
            return PartialView("_PartialViewToYazarList", rep.List());
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Insert(Yazar yazar)
        {
            rep.Insert(yazar);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id != null)
            {
                var returnId = db.yazars.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    return View(returnId);
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
          
        }
        [HttpPost]
        public ActionResult Update(int? id, Yazar yazar)
        {
            if (id != null)
            {
                var returnId = db.yazars.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    returnId.YazarAd = yazar.YazarAd;
                    returnId.YazarSoyad = yazar.YazarSoyad;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var returnId = db.yazars.Where(x => x.Id == id).FirstOrDefault();
                if (returnId != null)
                {
                    db.yazars.Remove(returnId);
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