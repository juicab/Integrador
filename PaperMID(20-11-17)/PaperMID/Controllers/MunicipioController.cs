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
            oMunicipio.Obtener_Municipio(id);
            var municipioBO = new MunicipioBO();
            ViewBag.IdEstado1 = new SelectList(municipioBO.Estados = municipioBO.Estados = oMunicipio.ListaEstado(), "IdEstado", "NombreEdo",oMunicipio.IdEstado1);
            return View(oMunicipio.Obtener_Municipio(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActuaDatosMuni(String IdMunicipio, String NombreMuni, String IdEstado1)
        {
            _MunicipioBO = new MunicipioBO();
            _MunicipioBO.IdMunicipio = Convert.ToInt32(IdMunicipio);
            _MunicipioBO.NombreMuni = NombreMuni;
            _MunicipioBO.IdEstado1 = Convert.ToInt32(IdEstado1);
            oMunicipio.Modificar(_MunicipioBO);
            return RedirectToAction("Municipio", "Municipio");
        }

        public ActionResult EliminarMuni(string id)
        {
            int clave = int.Parse(id);
            oMunicipio.Eliminar(clave);
            return RedirectToAction("Municipio", "Municipio");
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