using PersonelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMVCUI.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        DepartmanMVCEntities6 db = new DepartmanMVCEntities6();
        // GET: Security
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciInDb = db.Kullanici.FirstOrDefault(x=>x.Ad==kullanici.Ad && x.Sifre== kullanici.Sifre);
            if (kullaniciInDb!=null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.Ad, false);
                return RedirectToAction("Index","Departman");
            }
            else
            {
                ViewBag.Mesaj = "Gçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}