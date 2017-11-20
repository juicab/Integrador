using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.BO;

namespace PaperMID.Controllers
{
    public class MetodoPagoController : Controller
    {
        // GET: TipoProducto
        MetodoPagoModel oMetodoPagoModel = new MetodoPagoModel();

        public ActionResult MetodoPago()
        {
            return View();
        }
        public ActionResult AgregarMetodoPago(MetodoPagoBO oMetodoPag)
        {
            oMetodoPagoModel.Agregar(oMetodoPag);
            return RedirectToAction("MetodoPago", "MetodoPago");
        }
        public ActionResult ActualizarMetodoPago(int id)
        {
            return View(oMetodoPagoModel.RecuperarMetPago(id));
        }
        public ActionResult ActualizarDatosMetPag(MetodoPagoBO oMetPag)
        {
            oMetodoPagoModel.Modificar(oMetPag);
            MetodoPago();
            return View("MetodoPago");
        }
        [ChildActionOnly]
        public ActionResult MostrarMetPag()
        {
            return PartialView(oMetodoPagoModel.Mostrar());
        }
        public ActionResult Eliminar_MetPag(string id)
        {
            int clave = int.Parse(id);
            oMetodoPagoModel.Eliminar(clave);
            MetodoPago();
            return View("MetodoPago");
        }
    }
}