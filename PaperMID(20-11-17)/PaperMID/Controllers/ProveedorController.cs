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
        ProveedorModel _ProvMod;
        BO.ProveedorBO _ProveedorBO;
        public ProveedorController()
        {
            _ProvMod = new ProveedorModel();
        }
        public ActionResult Proveedor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Proveedor(String NombreProv,String TelefonoProv,String CorreoProv)
        {
            _ProveedorBO = new ProveedorBO();

            _ProveedorBO.NombreProv = NombreProv;
            _ProveedorBO.TelefonoProv = TelefonoProv;
            _ProveedorBO.CorreoProv = CorreoProv;
            _ProvMod.Agregar(_ProveedorBO);

            return RedirectToAction("Proveedor", "Proveedor");
        }
        public ActionResult Actualizar_Proveedor(int id)
        {
            return View(_ProvMod.Recuperar_Proveedor(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarDatos_Proveedor(String IdProveedor, String NombreProv, String TelefonoProv, String CorreoProv)
        {
            _ProveedorBO = new ProveedorBO();

            _ProveedorBO.idProveedor = Convert.ToInt32(IdProveedor);
            _ProveedorBO.NombreProv = NombreProv;
            _ProveedorBO.TelefonoProv = TelefonoProv;
            _ProveedorBO.CorreoProv = CorreoProv;

            _ProvMod.Modificar(_ProveedorBO);
            return View("Proveedor");
        }
        public ActionResult EliminarProveedor(string id)
        {
            int Clave = int.Parse(id);
            _ProvMod.Eliminar(Clave);
            return View("Proveedor");
        }

        [ChildActionOnly]
        public ActionResult MostrarListaProveedor()
        {
            return PartialView(_ProvMod.Mostrar());
        }
    }
}