using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class PaisController : Controller
    {
        // GET: Pais
        PaisModel oPais = new PaisModel();

        public ActionResult Pais()
        {
            return View();
        }
        public ActionResult Agregar_Pais(PaisBO oPaisBO)
        {
            oPais.Agregar(oPaisBO);
            return View("Pais");
        }
        public ActionResult MostrarPais()
        {
            return View(oPais.Mostrar());
        }
        public ActionResult ActualizarPais(int id)
        {
            return View(oPais.Obtener_Pais(id));
        }

        public ActionResult ActuaDatosPais(PaisBO oPai)
        {
            oPais.Modificar(oPai);
            MostrarPais();
            return View("Pais");
        }

        public ActionResult EliminarPais(string id)
        {
            int clave = int.Parse(id);
            oPais.Eliminar(clave);
            MostrarPais();
            return View("Pais");
        }

        [ChildActionOnly]
        public ActionResult MostrarPaisParcial()
        {
            return PartialView(oPais.Mostrar());
        }
    }
}