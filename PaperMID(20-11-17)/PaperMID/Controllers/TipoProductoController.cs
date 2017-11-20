using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.BO;

namespace PaperMID.Controllers
{
    public class TipoProductoController : Controller
    {
        // GET: TipoProducto
        TipoProductoModel tProdMod = new TipoProductoModel();

        public ActionResult TipoProducto()
        {
            return View();
        }
        public ActionResult Agregar_TProd(TipoProductoBO oTprod)
        {
            tProdMod.Agregar(oTprod);
            return RedirectToAction("TipoProducto", "TipoProducto");
        }
        public ActionResult Actualizar_TPro(int id)
        {
            return View(tProdMod.RecuperarTipo(id));
        }
        public ActionResult Actualizar_DatosTPro(TipoProductoBO OTprod)
        {
            tProdMod.Modificar(OTprod);
            TipoProducto();
            return View("TipoProducto");
        }
        [ChildActionOnly]
        public ActionResult MostrarTProd()
        {
            return PartialView(tProdMod.Mostrar());
        }
        public ActionResult Eliminar_TProd(string id)
        {
            int clave = int.Parse(id);
            tProdMod.Eliminar(clave);
            TipoProducto();
            return View("TipoProducto");
        }
    }
}