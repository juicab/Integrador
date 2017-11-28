using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        
        EmpresaModel oEmpresa = new EmpresaModel();
        public ActionResult ActualizarEmpresa()
        {
            return View(oEmpresa.Obtener_Empresa(1));
        }

        public ActionResult ActuaDatosEmpre(EmpresaBO oEmpre)
        {
            oEmpresa.Modificar(oEmpre);
            ActualizarEmpresa();
            return View("ActualizarEmpresa");
        }
    }
}