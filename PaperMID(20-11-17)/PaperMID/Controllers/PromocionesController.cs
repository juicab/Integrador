using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class PromocionesController : Controller
    {
        // GET: Promociones
        PromocionesModel PromoModel = new PromocionesModel();
        public ActionResult Promociones()
        {
            return View();
        }
        public ActionResult Agg_Promocion(PromocionesBO oPromBo)
        {
            PromoModel.Agregar(oPromBo);
            return RedirectToAction("Promociones", "Promociones");
        }

        public ActionResult ActualizarPromocion(int id)
        {
            return View(PromoModel.RecuperarPromo(id));
        }
        public ActionResult ActualizarDatosProm(PromocionesBO PromoBO)
        {
            PromoModel.Modificar(PromoBO);
            Promociones();
            return View("Promociones");
        }
        public ActionResult EliminarPromo(string id)
        {
            int Clave = int.Parse(id);
            PromoModel.Eliminar(Clave);
            return View("Promociones");
        }

        [ChildActionOnly]
        public ActionResult ProveedorParDWL()
        {
            var PromoBo = new PromocionesBO();
            PromoBo.Proveedores = PromoModel.ListaProveedor();
            return PartialView(PromoBo);
        }

        [ChildActionOnly]
        public ActionResult ComboProvedorPromo()
        {
            var PromoBO = new PromocionesBO();
            PromoBO.Proveedores = PromoModel.ListaProveedor();
            return PartialView(PromoBO);
        }
        [ChildActionOnly]
        public ActionResult ListarPromociones()
        {
            return PartialView(PromoModel.Mostrar());
        }
    }
}