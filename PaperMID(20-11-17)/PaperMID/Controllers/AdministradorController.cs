using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        RespaldoModel oRespaldo = new RespaldoModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Proveedor()
        {
            return View();
        }

        public ActionResult Respaldo()
        {
            oRespaldo.Respaldo();
            ViewBag.scrip = "Respaldo exitoso";
            return View("Index");
        }


    }
}