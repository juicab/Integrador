using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.BO;

namespace PaperMID.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor      
        ProveedorModel ProvMod = new ProveedorModel();
        public ActionResult Proveedor()
        {
            return View();
        }

        public ActionResult Agg_Proveedor(ProveedorBO oProvBO)
        {
            ProvMod.Agregar(oProvBO);
            return RedirectToAction("Proveedor", "Proveedor");
        }
        public ActionResult Actualizar_Proveedor(int id)
        {
            return View(ProvMod.Recuperar_Proveedor(id));
        }
        public ActionResult ActualizarDatos_Proveedor(ProveedorBO proBO)
        {
            ProvMod.Modificar(proBO);
            return View("Proveedor");
        }
        public ActionResult EliminarProveedor(string id)
        {
            int Clave = int.Parse(id);
            ProvMod.Eliminar(Clave);
            return View("Proveedor");
        }

        [ChildActionOnly]
        public ActionResult MostrarListaProveedor()
        {
            return PartialView(ProvMod.Mostrar());
        }

    }
}