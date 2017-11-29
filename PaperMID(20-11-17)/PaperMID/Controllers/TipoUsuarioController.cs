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
        TipoUsuarioModel oTuserModel;
        BO.TipoUsuarioBO _TipoBO;
        public TipoUsuarioController()
        {
            oTuserModel = new TipoUsuarioModel();
        }
        public ActionResult TipoUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarTipoUsuario(String TipoUsu)
        {
            _TipoBO = new TipoUsuarioBO();
            _TipoBO.TipoUsu = TipoUsu;
            oTuserModel.Agregar(_TipoBO);
            return RedirectToAction("TipoUsuario", "TipoUsuario");
        }
        public ActionResult ActualizarTipoUsuario(int id)
        {
            return View(oTuserModel.RecuperarTipo(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarDatosTUser(String IdTipoUsuario, String TipoUsu)
        {
            _TipoBO = new TipoUsuarioBO();
            _TipoBO.IdTipoUsuario = Convert.ToInt32(IdTipoUsuario);
            _TipoBO.TipoUsu = TipoUsu;
            oTuserModel.Modificar(_TipoBO);
            return RedirectToAction("TipoUsuario", "TipoUsuario");
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
            return RedirectToAction("TipoUsuario", "TipoUsuario");
        }
    }
}