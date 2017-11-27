using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        EstadoModel oEstado;
        BO.EstadoBO _EstadoBO;
        public EstadoController()
        {
            oEstado = new EstadoModel();
        }
        public ActionResult Estado()
        {
            var estadoBO = new EstadoBO();
            //Cargar el DropDownList por ViewBag para poder usar AJAX.
            ViewBag.IdPais1 = new SelectList(estadoBO.paises = estadoBO.paises = oEstado.ListaPais(), "IdPais", "NombrePais");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Estado(String NombreEdo, String IdPais1)
        {
            _EstadoBO = new EstadoBO();
            _EstadoBO.NombreEdo = NombreEdo;
            _EstadoBO.IdPais1 = Convert.ToInt32(IdPais1);
            oEstado.Agregar(_EstadoBO);
            return View("Estado");
        }
        
        public ActionResult ActualizarEstado(int id)
        {
            oEstado.Obtener_Estado(id);
            var estadoBO = new EstadoBO();
            //Cargar el DropDownList por ViewBag para poder usar AJAX.
            ViewBag.IdPais1 = new SelectList(estadoBO.paises = estadoBO.paises = oEstado.ListaPais(), "IdPais", "NombrePais",oEstado.IdPais1);
            return View(oEstado.Obtener_Estado(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActuaDatosEdo(String IdEstado,String NombreEdo, String IdPais1)
        {
            _EstadoBO = new EstadoBO();
            _EstadoBO.IdEstado = Convert.ToInt32(IdEstado);
            _EstadoBO.NombreEdo = NombreEdo;
            _EstadoBO.IdPais1 = Convert.ToInt32(IdPais1);
            oEstado.Modificar(_EstadoBO);
            
            return RedirectToAction("Estado", "Estado");
        }

        public ActionResult EliminarEdo(string id)
        {
            int clave = int.Parse(id);
            oEstado.Eliminar(clave);
            return RedirectToAction("Estado", "Estado");
        }

        [ChildActionOnly]
        public ActionResult ParcialPais()
        {
            var estadoBO = new EstadoBO();
            estadoBO.paises = oEstado.ListaPais();
            return PartialView(estadoBO);
        }

        [ChildActionOnly]
        public ActionResult MostrarEstadoParcial()
        {
            return PartialView(oEstado.Mostrar());
        }

        public ActionResult MostrarEstado()
        {
            return View(oEstado.Mostrar());
        }


    }
}