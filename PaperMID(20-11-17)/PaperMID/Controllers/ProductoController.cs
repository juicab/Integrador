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
        ProductoModel _oProductoModel;
        BO.ProductoBO _oProductoBO;
        // GET: Producto
        public ProductoController()
        {
            _oProductoModel = new ProductoModel();
        }
        public ActionResult Producto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Producto(String IdProducto,String NombreProd, String DescripcionProd, String PrecioProd,
            String DescuentoProd, String IdProveedor1, String CantidadDisponibleProd, String CantidadMinimaProd,
            String IdTipoProducto1)
        {
            _oProductoBO = new BO.ProductoBO();

            _oProductoBO.IdProducto = Convert.ToInt32(IdProducto);
            _oProductoBO.NombreProd = NombreProd;
            _oProductoBO.DescripcionProd = DescripcionProd;
            _oProductoBO.PrecioProd = Convert.ToDouble(PrecioProd);
            _oProductoBO.DescuentoProd = Convert.ToDouble(DescuentoProd);
            _oProductoBO.IdProveedor1 = Convert.ToInt32(IdProveedor1);
            _oProductoBO.CantidadDisponibleProd = Convert.ToInt32(CantidadDisponibleProd);
            _oProductoBO.CantidadMinimaProd = Convert.ToInt32(CantidadMinimaProd);
            _oProductoBO.IdTipoProducto1 = Convert.ToInt32(IdTipoProducto1);

            _oProductoModel.Agregar(_oProductoBO);

            return RedirectToAction("Producto", "Producto");
        }
        [ChildActionOnly]
        public ActionResult DropDownList_Proveedores()
        {
            var ProductoBO = new BO.ProductoBO();
            ProductoBO.Proveedores = _oProductoModel.Lista_Proveedor();
            return PartialView(ProductoBO);
        }

        [ChildActionOnly]
        public ActionResult DropDown_ListTipo_Producto()
        {
            var ProductoBO = new BO.ProductoBO();
            ProductoBO.TiposProducto = _oProductoModel.Lista_Tipo_Producto();
            return PartialView(ProductoBO);
        }

        [ChildActionOnly]
        public ActionResult List_Productos()
        {
            return PartialView(_oProductoModel.Mostrar());
        }


        public ActionResult Actualizar_Producto(String IdProducto)
        {
            return View(_oProductoModel.Recuperar_Datos_Producto(IdProducto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar_Datos_Producto(String IdProducto, String NombreProd, String DescripcionProd, String PrecioProd,
            String DescuentoProd, String IdProveedor1, String CantidadDisponibleProd, String CantidadMinimaProd,
            String IdTipoProducto1)
        {
            _oProductoBO = new BO.ProductoBO();

            _oProductoBO.IdProducto = Convert.ToInt32(IdProducto);
            _oProductoBO.NombreProd = NombreProd;
            _oProductoBO.DescripcionProd = DescripcionProd;
            _oProductoBO.PrecioProd = Convert.ToDouble(PrecioProd);
            _oProductoBO.DescuentoProd = Convert.ToDouble(DescuentoProd);
            _oProductoBO.IdProveedor1 = Convert.ToInt32(IdProveedor1);
            _oProductoBO.CantidadDisponibleProd = Convert.ToInt32(CantidadDisponibleProd);
            _oProductoBO.CantidadMinimaProd = Convert.ToInt32(CantidadMinimaProd);
            _oProductoBO.IdTipoProducto1 = Convert.ToInt32(IdTipoProducto1);

            _oProductoModel.Modificar(_oProductoBO);
            return RedirectToAction("Producto", "Producto");
        }
        public ActionResult Eliminar_Producto(String IdProducto)
        {
            _oProductoModel.Eliminar(IdProducto);
            return View("Producto");
        }
    }
}