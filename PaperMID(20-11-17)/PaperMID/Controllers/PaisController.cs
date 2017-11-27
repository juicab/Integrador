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
        PaisModel _oPais;
        BO.PaisBO _PaisBO;
        public PaisController()
        {
            _oPais = new PaisModel();
        }
        public ActionResult Pais()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Pais(String NombrePais)
        {
            _PaisBO = new PaisBO();
            _PaisBO.NombrePais = NombrePais;
            _oPais.Agregar(_PaisBO);
            return View("Pais");
        }
        public ActionResult MostrarPais()
        {
            return View(_oPais.Mostrar());
        }
        public ActionResult ActualizarPais(int id)
        {
            return View(_oPais.Obtener_Pais(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActuaDatosPais(String IdPais, String NombrePais)
        {
            _PaisBO = new PaisBO();
            _PaisBO.IdPais = Convert.ToInt32(IdPais);
            _PaisBO.NombrePais = NombrePais;
            _oPais.Modificar(_PaisBO);
            return View("Pais");
        }

        public ActionResult EliminarPais(string id)
        {
            int clave = int.Parse(id);
            _oPais.Eliminar(clave);
            return View("Pais");
        }

        [ChildActionOnly]
        public ActionResult MostrarPaisParcial()
        {
            return PartialView(_oPais.Mostrar());
        }
    }
}