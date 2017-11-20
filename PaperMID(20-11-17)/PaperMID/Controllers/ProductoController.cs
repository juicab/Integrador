using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class ProductoController : Controller
    {
        ProductoModel oProductoModel;
        BO.ProductoBO oProductoBO;
        // GET: Producto
        public ProductoController()
        {
            oProductoModel = new ProductoModel();
        }
        public ActionResult Producto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Producto(String NombreProd, String DescripcionProd, String PrecioProd,
            String DescuentoProd, String IdProveedor1, String CantidadDisponibleProd, String CantidadMinimaProd,
            String IdTipoProducto1)
        {
            oProductoBO = new BO.ProductoBO();

            oProductoBO.NombreProd = NombreProd;
            oProductoBO.DescripcionProd = DescripcionProd;
            oProductoBO.PrecioProd = Convert.ToDouble(PrecioProd);
            oProductoBO.DescuentoProd = Convert.ToDouble(DescuentoProd);
            oProductoBO.IdProveedor1 = Convert.ToInt32(IdProveedor1);
            oProductoBO.CantidadDisponibleProd = Convert.ToInt32(CantidadDisponibleProd);
            oProductoBO.CantidadMinimaProd = Convert.ToInt32(CantidadMinimaProd);
            oProductoBO.IdTipoProducto1 = Convert.ToInt32(IdTipoProducto1);

            oProductoModel.Agregar(oProductoBO);

            return RedirectToAction("Producto", "Producto");
        }
        [ChildActionOnly]
        public ActionResult DropDownList_Proveedores()
        {
            var ProductoBO = new BO.ProductoBO();
            ProductoBO.Proveedores = oProductoModel.Lista_Proveedor();
            return PartialView(ProductoBO);
        }

        [ChildActionOnly]
        public ActionResult DropDown_ListTipo_Producto()
        {
            var ProductoBO = new BO.ProductoBO();
            ProductoBO.TiposProducto = oProductoModel.Lista_Tipo_Producto();
            return PartialView(ProductoBO);
        }

        [ChildActionOnly]
        public ActionResult List_Productos()
        {
            return PartialView(oProductoModel.Mostrar());
        }


        public ActionResult Actualizar_Producto()
        {
            return View();
        }

        public ActionResult Eliminar_Producto()
        {
            return View();
        }
    }
}