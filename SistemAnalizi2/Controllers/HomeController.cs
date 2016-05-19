using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemAnalizi2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["sepet"] == null)
            {
                Session["sepet"] = new List<int>();
            }
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}