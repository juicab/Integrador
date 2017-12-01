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
        BO.DireccionBO _oDireccionBO;
        public UsuarioController()
        {
            oDireccionModel = new DireccionModel();
            oModel = new UsuarioModel();
        }
        // GET: Usuario
        public ActionResult Usuario()
        {
            var direccionBO = new BO.DireccionBO();           
            //Cargar el DropDownList por ViewBag para poder usar AJAX.
            ViewBag.IdMunicipio1 = new SelectList(direccionBO.municipios = oDireccionModel.ListaMunicipios(), "IdMunicipio", "NombreMuni");
            var UsuarioBO = new BO.UsuarioBO();
            //Cargar el DropDownList por ViewBag para poder usar AJAX.
            ViewBag.IdTipoUsuario1 = new SelectList(UsuarioBO.TiposUsuario = oModel.Lista_Tipo_Usuario(), "IdTipoUsuario", "TipoUsu");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Usuario(String NombreUsu,String ApellidoPaternoUsu,
            String ApellidoMaternoUsu,String FechaNacimientoUsu,String TelefonoUsu,String CorreoUsu,String Usuario,String ContraseñaUsu,
            String ConfirmarContraseñaUsu, HttpPostedFileBase ImagenUsu,String CalleDir,String NumInteDir,String NumExteDir,String CruzaDir,
            String ColoniaDir,String CPDir,String IdMunicipio1)
        {
            _oDireccionBO = new BO.DireccionBO();
            _oDireccionBO.CalleDir = CalleDir;
            _oDireccionBO.NumInteDir = NumInteDir;
            _oDireccionBO.NumExteDir = NumExteDir;
            _oDireccionBO.CruzaDir = CruzaDir;
            _oDireccionBO.ColoniaDir = ColoniaDir;
            _oDireccionBO.CPDir = CPDir;
            _oDireccionBO.IdMunicipio1 = Convert.ToInt32(IdMunicipio1);
            oModel = new UsuarioModel();
            oUsuarioBO = new BO.UsuarioBO();
            oUsuarioBO.NombreUsu = NombreUsu;
            oUsuarioBO.ApellidoPaternoUsu = ApellidoPaternoUsu;
            oUsuarioBO.ApellidoMaternoUsu = ApellidoMaternoUsu;
            oUsuarioBO.FechaNacimientoUsu = FechaNacimientoUsu;
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
            oDireccionModel.Agregar(_oDireccionBO);
            oModel.Agregar(oUsuarioBO);
            return RedirectToAction("IniciarSesion", "Publico");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Usuario_Administrador(String NombreUsu, String ApellidoPaternoUsu,
    String ApellidoMaternoUsu, String FechaNacimientoUsu, String TelefonoUsu, String CorreoUsu, String Usuario, String ContraseñaUsu,
    String ConfirmarContraseñaUsu, HttpPostedFileBase ImagenUsu, String CalleDir, String NumInteDir, String NumExteDir, String CruzaDir,
    String ColoniaDir, String CPDir, String IdMunicipio1)
        {
            _oDireccionBO = new BO.DireccionBO();
            _oDireccionBO.CalleDir = CalleDir;
            _oDireccionBO.NumInteDir = NumInteDir;
            _oDireccionBO.NumExteDir = NumExteDir;
            _oDireccionBO.CruzaDir = CruzaDir;
            _oDireccionBO.ColoniaDir = ColoniaDir;
            _oDireccionBO.CPDir = CPDir;
            _oDireccionBO.IdMunicipio1 = Convert.ToInt32(IdMunicipio1);
            oModel = new UsuarioModel();
            oUsuarioBO = new BO.UsuarioBO();
            oUsuarioBO.NombreUsu = NombreUsu;
            oUsuarioBO.ApellidoPaternoUsu = ApellidoPaternoUsu;
            oUsuarioBO.ApellidoMaternoUsu = ApellidoMaternoUsu;
            oUsuarioBO.FechaNacimientoUsu = FechaNacimientoUsu;
            oUsuarioBO.TelefonoUsu = TelefonoUsu;
            oUsuarioBO.CorreoUsu = CorreoUsu;
            oUsuarioBO.ContraseñaUsu = ContraseñaUsu;
            oUsuarioBO.Usuario = Usuario;

            if (ImagenUsu != null && ImagenUsu.ContentLength > 0)
            {
                oUsuarioBO.ImagenUsu = new byte[ImagenUsu.ContentLength];
                ImagenUsu.InputStream.Read(oUsuarioBO.ImagenUsu, 0, ImagenUsu.ContentLength);
            }
            else
            {
                oUsuarioBO.ImagenUsu = null;
            }
            oDireccionModel.Agregar(_oDireccionBO);
            oModel.Agregar(oUsuarioBO);
            return RedirectToAction("Usuario", "Usuario");
        }
        [ChildActionOnly]
        public ActionResult List_Usuarios()
        {
            return PartialView(oModel.Mostrar());
        }
        public ActionResult Eliminar_Usuario(string IdUsuario)
        {
            oModel.Eliminar(IdUsuario);
            return RedirectToAction("Usuario", "Usuario");
        }
        public ActionResult Actualizar_Usuario(string IdUsuario)
        {
            Obtener_Dic_Usuario(IdUsuario);//Llamo al método - para pasarle el IdUsuario.
            return View(oModel.Obtener_Usuario(IdUsuario));
        }
        [ChildActionOnly]
        public ActionResult Obtener_Dic_Usuario(string IdUsuario)
        {
            oModel.Obtener_Usuario(IdUsuario);
            return PartialView(oModel.Obtener_Direccion_Usuario());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar_Datos_Usuario_Administrador(String NombreUsu, String ApellidoPaternoUsu,
String ApellidoMaternoUsu, String FechaNacimientoUsu, String TelefonoUsu, String CorreoUsu, String Usuario, String ContraseñaUsu,
String ConfirmarContraseñaUsu, HttpPostedFileBase ImagenUsu, String CalleDir, String NumInteDir, String NumExteDir, String CruzaDir,
String ColoniaDir, String CPDir, String IdMunicipio1)
        {
            _oDireccionBO = new BO.DireccionBO();
            _oDireccionBO.CalleDir = CalleDir;
            _oDireccionBO.NumInteDir = NumInteDir;
            _oDireccionBO.NumExteDir = NumExteDir;
            _oDireccionBO.CruzaDir = CruzaDir;
            _oDireccionBO.ColoniaDir = ColoniaDir;
            _oDireccionBO.CPDir = CPDir;
            _oDireccionBO.IdMunicipio1 = Convert.ToInt32(IdMunicipio1);
            oModel = new UsuarioModel();
            oUsuarioBO = new BO.UsuarioBO();
            oUsuarioBO.NombreUsu = NombreUsu;
            oUsuarioBO.ApellidoPaternoUsu = ApellidoPaternoUsu;
            oUsuarioBO.ApellidoMaternoUsu = ApellidoMaternoUsu;
            oUsuarioBO.FechaNacimientoUsu = FechaNacimientoUsu;
            oUsuarioBO.TelefonoUsu = TelefonoUsu;
            oUsuarioBO.CorreoUsu = CorreoUsu;
            oUsuarioBO.ContraseñaUsu = ContraseñaUsu;
            oUsuarioBO.Usuario = Usuario;

            if (ImagenUsu != null && ImagenUsu.ContentLength > 0)
            {
                oUsuarioBO.ImagenUsu = new byte[ImagenUsu.ContentLength];
                ImagenUsu.InputStream.Read(oUsuarioBO.ImagenUsu, 0, ImagenUsu.ContentLength);
            }
            else
            {
                oUsuarioBO.ImagenUsu = null;
            }
            oDireccionModel.Agregar(_oDireccionBO);
            oModel.Agregar(oUsuarioBO);
            return RedirectToAction("Usuario", "Usuario");
        }
    }
}