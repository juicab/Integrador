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
        EstadoModel oEstado = new EstadoModel();
        public ActionResult Estado()
        {
            return View();
        }
        public ActionResult Agregar_Estado(EstadoBO oEstadoBO)
        {
            oEstado.Agregar(oEstadoBO);
            return View("Estado");
        }
        
        public ActionResult ActualizarEstado(int id)
        {
            return View(oEstado.Obtener_Estado(id));
        }

        public ActionResult ActuaDatosEdo(EstadoBO oEdo)
        {
            oEstado.Modificar(oEdo);
            Estado();
            return View("Estado");
        }

        public ActionResult EliminarEdo(string id)
        {
            int clave = int.Parse(id);
            oEstado.Eliminar(clave);
            return View("Estado");
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