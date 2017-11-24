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
        BO.FotoBO _oFotoBO;
        FotoModel _oFotoModel;
        private String Gl_Id_Producto;
        private int Gl_Id_Tipo_Producto1;
        // GET: Producto
        public ProductoController()
        {
            _oProductoModel = new ProductoModel();
        }
        public ActionResult Producto()
        {
            var ProductoBO = new BO.ProductoBO();
            //Cargar el DropDownList por ViewBag para poder usar AJAX.
            ViewBag.IdTipoProducto1 = new SelectList(ProductoBO.TiposProducto = _oProductoModel.Lista_Tipo_Producto(), "IdTipoProducto", "TipoProducto");
            ViewBag.IdProveedor1 = new SelectList(ProductoBO.Proveedores = _oProductoModel.Lista_Proveedor(), "IdProveedor", "NombreProv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Producto(String IdProducto,String NombreProd, String DescripcionProd, String PrecioProd,
            String DescuentoProd, String IdProveedor1, String CantidadDisponibleProd, String CantidadMinimaProd,
            String IdTipoProducto1,HttpPostedFileBase ImagenProducto)
        {
            _oProductoBO = new BO.ProductoBO();
            _oFotoBO = new BO.FotoBO();

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

            if (ImagenProducto!=null&&ImagenProducto.ContentLength>0)
            {
                _oFotoBO.ImagenFoto = new byte[ImagenProducto.ContentLength];
                ImagenProducto.InputStream.Read(_oFotoBO.ImagenFoto, 0, ImagenProducto.ContentLength);
                _oFotoBO.PrincipalFoto = true;
                _oFotoBO.IdProducto = Convert.ToInt32(IdProducto);

                _oFotoModel.Agregar(_oFotoBO);
            }
            

            return RedirectToAction("Producto", "Producto");
        }

        [ChildActionOnly]
        public ActionResult List_Productos()
        {
            return PartialView(_oProductoModel.Mostrar());
        }

        public ActionResult Obtener_Datos(String IdProducto)
        {
            _oProductoModel.Recuperar_Datos_Producto(IdProducto);
            Gl_Id_Producto = IdProducto;
            Gl_Id_Tipo_Producto1 = _oProductoModel.IdTipoProducto1;
            return RedirectToAction("Actualizar_Producto", "Producto");
        }
        public ActionResult Actualizar_Producto(String IdProducto)
        {
            _oProductoModel.Recuperar_Datos_Producto(IdProducto);
            var ProductoBO = new BO.ProductoBO();

            //Cargar el DropDownList por ViewBag para poder usar AJAX.
            ViewBag.IdTipoProducto1 = new SelectList(ProductoBO.TiposProducto = _oProductoModel.Lista_Tipo_Producto(), "IdTipoProducto", "TipoProducto",_oProductoModel.IdTipoProducto1);
            ViewBag.IdProveedor1 = new SelectList(ProductoBO.Proveedores = _oProductoModel.Lista_Proveedor(), "IdProveedor", "NombreProv");
            
            return View(_oProductoModel.Recuperar_Datos_Producto(Gl_Id_Producto));
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
        [ChildActionOnly]
        //public ActionResult DropDownList()
        //{

        //}
    }
}