using Project.BLL.Repositories.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.MVCUI.Models.PageVMs;
using Project.VM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class RegisterController : Controller
    {
        AppUserRepository _apRep;
        ProfileRepository _proRep;

        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _proRep = new ProfileRepository();
        }
        public ActionResult RegisterNow()
        {
            return View();
        }


        [HttpPost]
       
        public ActionResult RegisterNow(AppUserVM appUser, ProfileVM profile)
        {
            if (_apRep.Any(x => x.UserName == appUser.UserName))
            {
                ViewBag.ZatenVar = "Kullanıcı ismi daha önce alınmıs";
                return View();
            }
            else if (_apRep.Any(x => x.Email == appUser.Email))
            {
                ViewBag.ZatenVar = "Email zaten kayıtlı";
                return View();
            }

            appUser.Password = DantexCrypt.Crypt(appUser.Password); //sifreyi kriptoladık

            AppUser domainUser = new AppUser
            {
                UserName = appUser.UserName,
                Password = appUser.Password,
                Email = appUser.Email
            };

            _apRep.Add(domainUser); //siz kullanıcı yanında  profili eklemek isterseniz öncelikle Repository'nin bu metodunu AppUser icin calıstırmalısınız...Cünkü AppUser'in ID'si ilk basta olusmalı...Cünkü bizim kurdugumuz birebir ilişkide AppUser zorunlu olan alan, Profile ise opsiyonel alandır...Dolayısıyla Profile'in ID'si identity degildir...o yüzden Profile eklenecekken ID belirlenmek zorundadır(manuel)...Birebir ilişki oldugundan dolayı Profile'in ID'si ile AppUser'in ID'si tutmak zorundadır... İlk basta AppUSer'in ID'siSaveChanges ile olusur (Repository sayesinde) ki sonra Profile'i rahatca ekleyebilelim

            string gonderilecekMail = "Tebrikler ..Hesabınız olusturulmustur...Hesabınızı aktive etmek icin http://localhost:58728/Register/Activation/" + domainUser.ActivationCode + " linkine tıklayabilirsiniz";

            MailService.Send(appUser.Email, body: gonderilecekMail, subject: "Hesap Aktivasyon!!");


            if(!string.IsNullOrEmpty(profile.FirstName.Trim()) || !string.IsNullOrEmpty(profile.LastName.Trim()))
            {
                AppUserProfile domainProfile = new AppUserProfile
                {
                    ID = domainUser.ID,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                };
            }

           

            return View("RegisterOK");
        }


        public ActionResult RegisterOK()
        {
            return View();
        }

        public ActionResult Activation(Guid id)
        {
            AppUser aktifEdilecek = _apRep.FirstOrDefault(x => x.ActivationCode == id);
            if (aktifEdilecek != null)
            {
                aktifEdilecek.Active = true;
                _apRep.Update(aktifEdilecek);
                TempData["HesapAktifMi"] = "Hesabınız aktif hale getirildi";
                return RedirectToAction("Login", "Home");
            }

            //Süpheli bir aktivite
            TempData["HesapAktifMi"] = "Hesabınız bulunamadı";
            return RedirectToAction("Login", "Home");
        }
    }
}