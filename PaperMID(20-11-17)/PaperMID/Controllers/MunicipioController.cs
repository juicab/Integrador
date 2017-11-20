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
        MunicipioModel oMunicipio = new MunicipioModel();
        public ActionResult Municipio()
        {
            return View();
        }
        public ActionResult Agregar_Municipio(MunicipioBO oMunicipioBO)
        {
            oMunicipio.Agregar(oMunicipioBO);
            return View("Municipio");
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