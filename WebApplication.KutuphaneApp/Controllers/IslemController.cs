using _01_KT.Entity.Entity;
using _03_KT.PresentationLayer.Repository;
using System.Web.Mvc;
using System.Linq;
using _02_KT.DataModel.Model;
using _01_KT.Entity.View;

namespace WebApplication.KutuphaneApp.Controllers
{
    public class IslemController : Controller
    {
        GenericRepository<Islem> rep = null;
        AppDbContext db = null;
        public IslemController()
        {
            rep = new GenericRepository<Islem>();
            db = new AppDbContext();
        }
        public ActionResult Index()
        {
            ViewBag.Ogrenciler = new SelectList(db.Ogrenci.ToList(), "Id", "OgrenciAd");
            ViewBag.Kitaplar = new SelectList(db.Kitaps.ToList(), "Id", "KitapAdi");
            return View();
        }
        public PartialViewResult PartialViewToList()
        {
            var list = db.Database.SqlQuery<IslemView>(@"select 
            i.Id,
            ogr.OgrenciAd,
            kt.KitapAdi,
            i.ATarih, 
            i.VTarih
            from  Islems as i
            inner join Ogrencis as ogr on ogr.Id = i.OgrenciId
            inner join Kitaps as kt on kt.Id = i.KitapId").ToHashSet();
            return PartialView("_PartialPageIslemToList", list);
        }
        [HttpPost]
        public ActionResult Insert(Islem islem)
        {
            rep.Insert(islem);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int? id)
        {
            ViewBag.Ogrenciler = new SelectList(db.Ogrenci.ToList(), "Id", "OgrenciAd");
            ViewBag.Kitaplar = new SelectList(db.Kitaps.ToList(), "Id", "KitapAdi");
            if (id != null)
            {
                var returnValue = db.Islems.Where(x => x.Id == id).FirstOrDefault();
                if (returnValue != null)
                {
                    return View(returnValue);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Guncelle(int? id,Islem islem)
        {
            ViewBag.Ogrenciler = new SelectList(db.Ogrenci.ToList(), "Id", "OgrenciAd");
            ViewBag.Kitaplar = new SelectList(db.Kitaps.ToList(), "Id", "KitapAdi");

            if (id != null)
            {
                var returnValue = db.Islems.Where(x => x.Id == id).FirstOrDefault();
                if (returnValue != null)
                {

                    returnValue.OgrenciId = islem.OgrenciId.ToString();
                    returnValue.kitapId = islem.kitapId;
                    returnValue.ATarih = islem.ATarih;
                    returnValue.VTarih = islem.VTarih;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
        public ActionResult Sil(int? id)
        {
            Islem returnId = db.Islems.Where(x => x.Id == id).FirstOrDefault();
            if (returnId != null)
            {
                db.Islems.Remove(returnId);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }  
}