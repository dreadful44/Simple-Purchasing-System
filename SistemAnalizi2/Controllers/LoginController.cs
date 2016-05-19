using SistemAnalizi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemAnalizi2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(musteriler musteri)
        {
            if (ModelState.IsValid)
            {
                using (Model1 db = new Model1())
                {
                    try
                    {
                        var kullaniciAdi = musteri.kullaniciAdi.ToString();
                        var sifre = musteri.sifre.ToString();

                        var musteriUser = db.musterilers.Where(u => u.kullaniciAdi == kullaniciAdi && u.sifre == sifre).FirstOrDefault();


                        if (musteriUser != null)
                        {
                            Session["musteriID"] = musteriUser.musterilerID.ToString();
                            Session["kullaniciAdi"] = musteriUser.kullaniciAdi.ToString();
                            Session["yetki"] = "musteri";
                            Session["girisYaptiMi"] = true;

                            return RedirectToAction("index", "Home");
                        }
                        else {
                            var yoneticiUser = db.yoneticilers.Where(y => y.kullaniciAdi == kullaniciAdi &&
                        y.sifre == sifre).FirstOrDefault();

                            if (yoneticiUser != null)
                            {
                                Session["yoneticiID"] = yoneticiUser.yoneticilerID.ToString();
                                Session["kullaniciAdi"] = yoneticiUser.kullaniciAdi.ToString();
                                Session["yetki"] = "yonetici";
                                Session["girisYaptiMi"] = true;

                                return RedirectToAction("index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                            }
                        }
                    }
                    catch
                    {
                        return View();
                    }

                }

            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(musteriler musteri)
        {
            if (ModelState.IsValid)
            {
                using (Model1 db = new Model1())
                {
                    try
                    {
                        var kullaniciAdiKontrolUser = db.musterilers.Where(u => u.kullaniciAdi == musteri.kullaniciAdi).FirstOrDefault();
                        var epostaKontrolUser = db.musterilers.Where(u => u.eposta == musteri.eposta).FirstOrDefault();


                        if (kullaniciAdiKontrolUser != null)
                        {
                            ModelState.AddModelError("", "Bu kullanıcı adı mevcut.");

                            return View();
                        }
                        else if (epostaKontrolUser != null)
                        {
                            ModelState.AddModelError("", "Bu eposta mevcut.");
                        }
                        else
                        {
                            db.musterilers.Add(musteri);
                            db.SaveChanges();

                            return RedirectToAction("index", "Login");
                        }
                    }
                    catch
                    {
                        return View();
                    }

                }

            }



            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("index", "Home");
        }
    }
}