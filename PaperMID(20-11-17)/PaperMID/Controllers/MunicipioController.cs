using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class MunicipioController : Controller
    {
        // GET: Municipio
        MunicipioModel oMunicipio;
        BO.MunicipioBO _MunicipioBO;
        public MunicipioController()
        {
            oMunicipio = new MunicipioModel();
        }
        public ActionResult Municipio()
        {
            var municipioBO = new MunicipioBO();       
            ViewBag.IdEstado1 = new SelectList(municipioBO.Estados = municipioBO.Estados = oMunicipio.ListaEstado(), "IdEstado", "NombreEdo");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Municipio(String NombreMuni, String IdEstado1)
        {
            _MunicipioBO = new MunicipioBO();
            _MunicipioBO.NombreMuni = NombreMuni;
            _MunicipioBO.IdEstado1 = Convert.ToInt32(IdEstado1);
            oMunicipio.Agregar(_MunicipioBO);
            return RedirectToAction("Municipio", "Municipio");
        }

        public ActionResult ActualizarMunicipio(int id)
        {
            return View(oMunicipio.Obtener_Municipio(id));
        }

        public ActionResult ActuaDatosMuni(MunicipioBO oMuni)
        {
            oMunicipio.Modificar(oMuni);
            return View("Municipio");
        }

        public ActionResult EliminarMuni(string id)
        {
            int clave = int.Parse(id);
            oMunicipio.Eliminar(clave);
            return View("Municipio");
        }

        [ChildActionOnly]
        public ActionResult ComboEstado()
        {
            var municipioBO = new MunicipioBO();
            municipioBO.Estados = oMunicipio.ListaEstado();
            return PartialView(municipioBO);
        }
        [ChildActionOnly]
        public ActionResult ListaMunicipios()
        {
            return PartialView(oMunicipio.Mostrar());
        }

    }
}