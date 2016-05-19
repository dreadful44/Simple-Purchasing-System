using SistemAnalizi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemAnalizi2.Controllers
{
    public class SepetController : Controller
    {

        private Model1 db = new Model1();

        // GET: Sepet
        public ActionResult Index()
        {
            List<int> sepetList = Session["sepet"] as List<int>;

            List<urunler> urunlerList = new List<urunler>();

            if(sepetList != null)
            {
                for (var i = 0; i < sepetList.Count; i++)
                {
                    urunler urunler = db.urunlers.Find(sepetList[i]);
                    urunlerList.Add(urunler);
                }
            }

            

            return View(urunlerList);
        }


        public ActionResult OdemeYap()
        {

            return View();
        }

        public ActionResult Delete(int urunID)
        {

            if(ModelState.IsValid)
            {
                if(urunID != null)
                {
                    var sepet = Session["sepet"] as List<int>;
                    sepet.Remove(urunID);

                    Session["sepet"] = sepet;
                }
            }
            return RedirectToAction("index", "sepet");
        }
    }
}