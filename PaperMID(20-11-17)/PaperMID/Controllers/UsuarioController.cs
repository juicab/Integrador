using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using System.IO;
using System.Globalization;
namespace PaperMID.Controllers
{
    public class UsuarioController : Controller
    {
        DireccionModel oDireccionModel;
        UsuarioModel oModel;
        BO.UsuarioBO oUsuarioBO;
        // GET: Usuario
        public ActionResult Usuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(BO.DireccionBO oDirreccionBO,HttpPostedFileBase ImagenUsu,String NombreUsu,String ApellidoPaternoUsu,
            String ApellidoMaternoUsu,String FechaNacimientoUsu,String TelefonoUsu,String CorreoUsu,String Usuario,String ContraseñaUsu,
            String ConfirmarContraseñaUsu)
        { 
            oDireccionModel = new DireccionModel();
            oModel = new UsuarioModel();
            oUsuarioBO = new BO.UsuarioBO();

            DateTime _fechaRelacion;
            if (String.IsNullOrEmpty(FechaNacimientoUsu))
            {
                _fechaRelacion = DateTime.Now;
            }
            else
            {
                _fechaRelacion = DateTime.Parse(FechaNacimientoUsu, new CultureInfo("en-CA"));
            }
            oUsuarioBO.NombreUsu = NombreUsu;
            oUsuarioBO.ApellidoPaternoUsu = ApellidoPaternoUsu;
            oUsuarioBO.ApellidoMaternoUsu = ApellidoMaternoUsu;
            oUsuarioBO.FechaNacimientoUsu = _fechaRelacion;
            oUsuarioBO.TelefonoUsu = TelefonoUsu;
            oUsuarioBO.CorreoUsu = CorreoUsu;
            oUsuarioBO.ContraseñaUsu = ContraseñaUsu;
            oUsuarioBO.Usuario = Usuario;

            if (ImagenUsu!=null&&ImagenUsu.ContentLength>0)
            {
                oUsuarioBO.ImagenUsu = new byte[ImagenUsu.ContentLength];
                ImagenUsu.InputStream.Read(oUsuarioBO.ImagenUsu, 0, ImagenUsu.ContentLength);
            }
            else
            {
                oUsuarioBO.ImagenUsu = null;
            } 
            oDireccionModel.Agregar(oDirreccionBO);
            oModel.Agregar(oUsuarioBO);
            return RedirectToAction("IniciarSesion", "Publico");
        }
    }
}