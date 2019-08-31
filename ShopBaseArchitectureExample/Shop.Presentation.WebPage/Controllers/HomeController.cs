using SelectPdf;
using Shop.Presentation.WebPage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Presentation.WebPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var boleta = new Boleta()
            {
                FechaDeVenta = DateTime.Now,
                Monto = 100,
                NombreCliente = "Daniel Carbajal",
                Serie = "B101-000001",
                Detalles = new List<Detalle>()
                {
                    new Detalle(){ Descripcion = "Manzana", SubTotal = 40},
                    new Detalle(){ Descripcion = "Pera", SubTotal = 60}
                }
            };
            boleta.CargarQr();
            return View(boleta);
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

        public ActionResult PDF()
        {
            MemoryStream file = new MemoryStream();
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertUrl(@"http://localhost:62712");
            doc.Save(file);
            doc.Close();
            Session["Daniel"] = 10;
            return File(file.ToArray(),"boleta.pdf");

        }

    }
}