using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;
using System.Globalization;

namespace PaperMID.Controllers
{
    public class PromocionesController : Controller
    {
        // GET: Promociones
        PromocionesModel PromoModel;
        BO.PromocionesBO _PromoBO;
        public PromocionesController()
        {
            PromoModel = new PromocionesModel();
        }
        public ActionResult Promociones()
        {
            var PromoBo = new PromocionesBO();
            ViewBag.IdProve = new SelectList(PromoBo.Proveedores = PromoModel.ListaProveedor(), "IdProveedor", "NombreProv");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agg_Promocion(String NombrePromo, String IdProve,String DescripcionPromo, String FechaInicioPromo,String FechaFinPromo)
        {
            _PromoBO = new PromocionesBO();
            _PromoBO.NombrePromo = NombrePromo;
            _PromoBO.IdProve = Convert.ToInt32(IdProve);
            _PromoBO.DescripcionPromo = DescripcionPromo;
            _PromoBO.FechaInicioPromo = FechaInicioPromo;
            _PromoBO.FechaFinPromo = FechaFinPromo;
            PromoModel.Agregar(_PromoBO);
            return RedirectToAction("Promociones", "Promociones");
        }

        public ActionResult ActualizarPromocion(int id)
        {
            var PromoBo = new PromocionesBO();
            PromoModel.RecuperarPromo(id);
            ViewBag.IdProve = new SelectList(PromoBo.Proveedores = PromoModel.ListaProveedor(), "IdProveedor", "NombreProv", PromoModel.IdProveedor1);
            return View(PromoModel.RecuperarPromo(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarDatosProm(String IdPromo,String NombrePromo, String IdProve, String DescripcionPromo, String FechaInicioPromo, String FechaFinPromo)
        {
            _PromoBO = new PromocionesBO();
            _PromoBO.IdPromo = Convert.ToInt32(IdPromo);
            _PromoBO.NombrePromo = NombrePromo;
            _PromoBO.IdProve = Convert.ToInt32(IdProve);
            _PromoBO.DescripcionPromo = DescripcionPromo;
            _PromoBO.FechaInicioPromo = FechaInicioPromo;
            _PromoBO.FechaFinPromo = FechaFinPromo;
            PromoModel.Modificar(_PromoBO);
            return RedirectToAction("Promociones", "Promociones");
        }
        public ActionResult EliminarPromo(string id)
        {
            int Clave = int.Parse(id);
            PromoModel.Eliminar(Clave);
            return RedirectToAction("Promociones", "Promociones");
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