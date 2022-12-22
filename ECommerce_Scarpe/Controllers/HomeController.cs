using ECommerce_Scarpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public ActionResult GestioneProdotti(int id)
        {

            return View(Prodotto.SelectSingleProdotto(id));
        }

        [HttpPost]
        public ActionResult GestioneProdotti(Prodotto prodotto)
        {
            Prodotto.EditSingleProdtto(prodotto);
            return RedirectToAction("Index");
        }

        public ActionResult AddProdotto()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddProdotto(Prodotto prodotto, HttpPostedFileBase fileUpload)
        {
            if(fileUpload.ContentLength > 0)
            {
                string fileName = fileUpload.FileName;
                string Path = Server.MapPath("/Content/FileUpload/" + fileName);
                fileUpload.SaveAs(Path);
                prodotto.ImgCopertina = fileName;
                prodotto.ImgDettaglio1 = fileName;
                prodotto.ImgDettaglio2 = fileName;
            }


            Prodotto.AddSingleProdtto(prodotto);
            return RedirectToAction("Index");
        }

    }
}