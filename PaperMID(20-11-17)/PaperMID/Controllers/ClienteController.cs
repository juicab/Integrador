using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.BO;

namespace PaperMID.Controllers
{
    public class ClienteController : Controller
    {
        ProductoModel oProductoModel = new ProductoModel();
        PublicoModel oPublicoModel = new PublicoModel();
        // GET: Cliente
        public ActionResult Index(int id=1)
        {

            return View(oPublicoModel.Obtener_Empresa(id));
        }
        public ActionResult ProductosRepCli(ProductoBO oProducto)
        {
            return View(oProductoModel.MostrarRep());
        }
    }
}