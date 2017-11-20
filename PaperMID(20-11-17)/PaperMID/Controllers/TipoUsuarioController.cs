using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.BO;


namespace PaperMID.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoProducto
        TipoUsuarioModel oTuserModel = new TipoUsuarioModel();

        public ActionResult TipoUsuario()
        {
            return View();
        }
        public ActionResult AgregarTipoUsuario(TipoUsuarioBO oTUser)
        {
            oTuserModel.Agregar(oTUser);
            return RedirectToAction("TipoUsuario", "TipoUsuario");
        }
        public ActionResult ActualizarTipoUsuario(int id)
        {
            return View(oTuserModel.RecuperarTipo(id));
        }
        public ActionResult ActualizarDatosTUser(TipoUsuarioBO OTUser)
        {
            oTuserModel.Modificar(OTUser);
            TipoUsuario();
            return View("TipoUsuario");
        }
        [ChildActionOnly]
        public ActionResult MostrarTUser()
        {
            return PartialView(oTuserModel.Mostrar());
        }
        public ActionResult Eliminar_TUSer(string id)
        {
            int clave = int.Parse(id);
            oTuserModel.Eliminar(clave);
            TipoUsuario();
            return View("TipoUsuario");
        }
    }
}