using ECommerce_Scarpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce_Scarpe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Prodotto> ListaScarpe = Prodotto.SelectAllProdotti();
            return View(ListaScarpe);
        }

        public ActionResult DetailsProduct(int id)
        {
            return View(Prodotto.SelectSingleProdotto(id));
        }
            
    }
}