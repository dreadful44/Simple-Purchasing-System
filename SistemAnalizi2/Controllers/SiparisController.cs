using SistemAnalizi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemAnalizi2.Controllers
{
    public class SiparisController : Controller
    {
        private Model1 db = new Model1();

        // GET: Siparis
        public ActionResult Index()
        {
            try
            {

                var musteriID = int.Parse(Session["musteriID"].ToString());

                var adres = db.adres.Where(u => u.musteriler.musterilerID == musteriID).ToList();
                return View(adres);
            }
            catch
            {
                return RedirectToAction("index", "home");
            }
            

            
        }

        public ActionResult Create()
        {
            ViewBag.korhan = db.ilcelers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(adre aaa)
        {

            try
            {
                var musteriID = Session["MusteriID"];

                aaa.musteriler_musterilerID = int.Parse(musteriID.ToString());
                db.adres.Add(aaa);
                db.SaveChanges();
            }
            catch
            {

            }
            



            return RedirectToAction("Index", "Siparis");
        }

        // GET: temp/Edit/5
        public ActionResult Edit(int id)
        {
            var adres = db.adres.Find(id);

            ViewBag.adres = adres.adres;
            ViewBag.adresTipi = adres.adresTipi;
            ViewBag.korhan = db.ilcelers.ToList();

            return View(adres);
        }

        // POST: temp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var result = db.adres.SingleOrDefault(b => b.adresID == id);
                if (result != null)
                {
                    result.adresTipi = collection["adresTipi"].ToString();
                    result.adres = collection["adres"].ToString();
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            
            return View(db.adres.Find(id));
        }

        // POST: temp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                adre adres = db.adres.First(x => x.adresID == id);
                db.adres.Remove(adres);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}