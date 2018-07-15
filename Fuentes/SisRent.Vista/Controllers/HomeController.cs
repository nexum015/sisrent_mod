﻿namespace SisRent.Vista.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rentar()
        {
            var vmmhAdmin = new Areas.Mantencion.Models.ViewModelMapperHelper();
            var model = new RentarViewModel
            {
                ListaComunas = new ViewModelMapperHelper().ListaComunas(),
                ListaServicios = vmmhAdmin.ListaServicios(),
                ListaVehiculos = vmmhAdmin.ListaVehiculos()
            };

            return View(model);
        }

        public ActionResult Informacion()
        {
            ViewBag.Message = "Información";

            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Contacto";

            return View();
        }
    }
}