using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.BO;

namespace PaperMID.Controllers
{
    public class PublicoController : Controller
    {
        LoginModel oLoginModel;
        DireccionModel oDireccionModel = new DireccionModel();
        BO.LoginBO oLoginBO;
  
        // GET: Inicio
        public ActionResult Index(int id = 1)
        {
            return View(oPublicoModel.Obtener_Empresa(id));
        }
        [AllowAnonymous]
        public ActionResult IniciarSesion()
        {
            return View();
        }
        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult Restablecer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String Usuario, String ContraseñaUsu)
        {
            oLoginBO = new LoginBO();
            oLoginModel = new LoginModel();

            oLoginBO.Usuario = Usuario;
            oLoginBO.ContraseñaUsu = ContraseñaUsu;

            oLoginModel.BuscarUsuario(oLoginBO);
            if (ModelState.IsValid)
            {
                if (oLoginModel.Comprobacion() == true)
                {
                    Session["IdUsuario"] = oLoginModel.IdUsuario;
                    Session["Usuario"] = oLoginModel.Usuario;
                    Session["ImagenUsu"] = oLoginModel.ImagenUsu;
                    return RedirectToAction("Index", oLoginModel.Modulo);
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Publico");
        }

        [ChildActionOnly]
        public ActionResult DireccionRegistro()
        {
            return PartialView();
        }
        [ChildActionOnly]
        
        public ActionResult MunicipioRegistro()
        {
            var direccionBO = new DireccionBO();
            direccionBO.municipios = oDireccionModel.ListaMunicipios();
            return PartialView(direccionBO);
        }

        PublicoModel oPublicoModel = new PublicoModel();
        ProductoModel oProductoModel = new ProductoModel();
        public ActionResult ProductosRep(ProductoBO oProducto)
        {
            return View(oProductoModel.MostrarRep());
        }
    }
}