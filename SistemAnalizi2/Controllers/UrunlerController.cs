using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemAnalizi2.Models;

namespace SistemAnalizi2.Controllers
{
    public class UrunlerController : Controller
    {
        private Model1 db = new Model1();

        // GET: urunler
        public ActionResult Index()
        {
            return View(db.urunlers.ToList());
        }

        // GET: urunler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urunler urunler = db.urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // GET: urunler/Create
        public ActionResult Create()
        {

            var markaList = db.markalars.ToList();
            var kategoriList = db.kategoris.ToList();

            ViewBag.markalar = markaList;
            ViewBag.kategoriler = kategoriList;

            return View();
        }

        // POST: urunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "urunAdi,fiyati,markalar_markaID,kategori_kategoriID,stokBilgisi_stokID")]
        urunler urunler, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                string stokSayisi = collection["stokBilgisi.stokSayisi"];
                stokBilgisi stok = new stokBilgisi();
                stok.stokSayisi = stokSayisi;
                db.stokBilgisis.Add(stok);
                db.SaveChanges();

                var stokID = db.stokBilgisis.Where(u => u.stokSayisi == stokSayisi).First();
                urunler.stokBilgisi_stokID = stokID.stokID;
                urunler.markalar_markaID = int.Parse(collection["markalar"].ToString());
                urunler.kategori_kategoriID = int.Parse(collection["kategoriler"].ToString());

                db.urunlers.Add(urunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urunler);
        }

        // GET: urunler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urunler urunler = db.urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: urunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "urunlerID,urunAdi,fiyati,markalar_markaID,kategori_kategoriID,stokBilgisi_stokID")] urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urunler);
        }

        // GET: urunler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urunler urunler = db.urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            urunler urunler = db.urunlers.Find(id);
            db.urunlers.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult sepeteAt(int urunID)
        {
            if(ModelState.IsValid)
            {
                List<int> sepet = HttpContext.Session["sepet"] as List<int>;
                if(sepet == null)
                {
                    sepet = new List<int>();
                }
                sepet.Add(urunID);
                Session["sepet"] = sepet;
            }
            return RedirectToAction("Index", "urunler");

            
        }
    }
}
