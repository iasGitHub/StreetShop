using GestionStock.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionStock.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GMailer.senMail("testapplication@gmail.com", "Test", "Paramètre d'envoi de notification par Mail");
            this.Flash(string.Format("Bienvenue sur l'application web StreetShop"), FlashLevel.Success);
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
        public ActionResult NosProduits()
        {
            ViewBag.Message = "Retrouvez toute la gamme de nos produits.";

            return View();
        }
    }
}