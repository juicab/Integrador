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
        TipoProductoModel tProdMod;
        BO.TipoProductoBO _TProductoBO;
        public TipoProductoController()
        {
            tProdMod = new TipoProductoModel();
        }
        public ActionResult TipoProducto()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_TProd(String TipoProducto)
        {
            _TProductoBO = new TipoProductoBO();
            _TProductoBO.TipoProducto = TipoProducto;
            tProdMod.Agregar(_TProductoBO);
            return RedirectToAction("TipoProducto", "TipoProducto");
        }
        public ActionResult Actualizar_TPro(int id)
        {
            return View(tProdMod.RecuperarTipo(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar_DatosTPro(String IdTipoProducto, String TipoProducto)
        {
            _TProductoBO = new TipoProductoBO();
            _TProductoBO.IdTipoProducto = Convert.ToInt32(IdTipoProducto);
            _TProductoBO.TipoProducto = TipoProducto;
            tProdMod.Modificar(_TProductoBO);
            return RedirectToAction("TipoProducto", "TipoProducto");
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
            return RedirectToAction("TipoProducto", "TipoProducto");
        }
    }
}