using PersonelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelMVCUI.ViewModels;

namespace PersonelMVCUI.Controllers
{
    [Authorize(Roles = "A,U")]
    public class PersonelController : Controller
    {
        DepartmanMVCEntities6 db = new DepartmanMVCEntities6();

        [OutputCache(Duration =30)]
        public ActionResult Index()
        {
            var model = db.Personel.Include(x => x.Departman).ToList();
            return View(model);
        }

        
        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel=new Personel()
            };
            return View("PersonelForm", model);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };
                return View("PersonelForm", model);
            }
            if (personel.Id == 0)
            {
                db.Personel.Add(personel);
            }
            else
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }
        public ActionResult Sil(int id)
        {
            var silenecekPersonel = db.Personel.Find(id);
            if(silenecekPersonel == null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silenecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelleriGetir(int id)
        {
            var model = db.Personel.Where(x => x.DepartmanId == id).ToList();
            return PartialView(model);
        }

        public int? ToplamMaas()
        {
            return db.Personel.Sum(x => x.Maas);
        }
    }
}