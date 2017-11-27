using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using System.Data;
using System.Data.SqlClient;
using PaperMID.BO;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace PaperMID.Controllers
{
    public class ReportesController : Controller
    {

        ConexionModel Con;
        public ReportesController() { Con = new ConexionModel(); }
        // GET: Reportes
        public ActionResult ReporteProveedor()
        {
            #region Datos dummy
            string query = ("SELECT IdProveedor, NombreProv, TelefonoProv, CorreoProv FROM Proveedor WHERE StatusProv=1");
            var result = Con.TablaConnsulta(query);
            List<ProveedorBO> Proveedor = new List<ProveedorBO>();
            foreach (DataRow Pro in result.Rows)
            {
                var ProveedorBO = new ProveedorBO();
                ProveedorBO.idProveedor = Convert.ToInt32(Pro[0].ToString());
                ProveedorBO.NombreProv = Pro[1].ToString();
                ProveedorBO.TelefonoProv = Pro[2].ToString();
                ProveedorBO.CorreoProv = Pro[3].ToString();
                Proveedor.Add(ProveedorBO);
            }
            #endregion Datos dummy
            string DirRepor = "~/Reportes/Reportes/";
            string urlArchivo = string.Format("{0}.{1}", "ProveedorRepor", "rdlc");
            string FullReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirRepor), urlArchivo);
            ReportViewer reporte = new ReportViewer();
            reporte.Reset();
            reporte.LocalReport.ReportPath = FullReport;
            ReportDataSource DatosDS = new ReportDataSource("DSProveedor", Proveedor);
            reporte.LocalReport.DataSources.Add(DatosDS);
            reporte.LocalReport.Refresh();
            byte[] file = reporte.LocalReport.Render("PDf");

            return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "Reporte_DetalleVenta.", "PDF"));
        }

        public ActionResult ReporteUsuarioClientes()
        {
            #region Datos dummy
            string query = ("Select IdUsuario,NombreUsu,ApellidoPaternoUsu,ApellidoMaternoUsu,TelefonoUsu,CorreoUsu From Usuario Where IdTipoUsuario1=2 and StatusUsu=1");
            var result = Con.TablaConnsulta(query);
            List<UsuarioBO> Clientes = new List<UsuarioBO>();
            foreach (DataRow client in result.Rows)
            {
                var UsuBo = new UsuarioBO();
                UsuBo.IdUsuario = Convert.ToInt32(client[0].ToString());
                UsuBo.NombreUsu = client[1].ToString();
                UsuBo.ApellidoPaternoUsu = client[2].ToString();
                UsuBo.ApellidoMaternoUsu = client[3].ToString();
                UsuBo.TelefonoUsu = client[4].ToString();
                UsuBo.CorreoUsu = client[5].ToString();
                Clientes.Add(UsuBo);
            }
            #endregion Datos dummy

            string DirRepor = "~/Reportes/Reportes/";
            string urlArchivo = string.Format("{0}.{1}", "ClienteRepor", "rdlc");
            string FullReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirRepor), urlArchivo);
            ReportViewer reporte = new ReportViewer();
            reporte.Reset();
            reporte.LocalReport.ReportPath = FullReport;
            ReportDataSource DatosDS = new ReportDataSource("DSCliente", Clientes);
            reporte.LocalReport.DataSources.Add(DatosDS);
            reporte.LocalReport.Refresh();
            byte[] file = reporte.LocalReport.Render("PDf");

            return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "Reportes_Clientes.", "PDF"));




        }

        public ActionResult ReporteUsuarioEmpleados()
        {
            #region Datos dummy
            string query = ("Select IdUsuario,NombreUsu,ApellidoPaternoUsu,ApellidoMaternoUsu,TelefonoUsu,CorreoUsu From Usuario Where IdTipoUsuario1=3 and StatusUsu=1");
            var result = Con.TablaConnsulta(query);
            List<UsuarioBO> Empleados = new List<UsuarioBO>();
            foreach (DataRow empleado in result.Rows)
            {
                var UsuBo = new UsuarioBO();
                UsuBo.IdUsuario = Convert.ToInt32(empleado[0].ToString());
                UsuBo.NombreUsu = empleado[1].ToString();
                UsuBo.ApellidoPaternoUsu = empleado[2].ToString();
                UsuBo.ApellidoMaternoUsu = empleado[3].ToString();
                UsuBo.TelefonoUsu = empleado[4].ToString();
                UsuBo.CorreoUsu = empleado[5].ToString();
                Empleados.Add(UsuBo);
            }
            #endregion Datos dummy

            string DirRepor = "~/Reportes/Reportes/";
            string urlArchivo = string.Format("{0}.{1}", "EmpleadoRepor", "rdlc");
            string FullReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirRepor), urlArchivo);
            ReportViewer reporte = new ReportViewer();
            reporte.Reset();
            reporte.LocalReport.ReportPath = FullReport;
            ReportDataSource DatosDS = new ReportDataSource("DSEmpleado", Empleados);
            reporte.LocalReport.DataSources.Add(DatosDS);
            reporte.LocalReport.Refresh();
            byte[] file = reporte.LocalReport.Render("PDf");

            return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "Reporte_Empleado.", "PDF"));

        }

        public ActionResult ReporteDetalleVenta()
        {
            #region Datos dummy
            string query = ("Select * From DetalleVenta");
            var result = Con.TablaConnsulta(query);
            List<DetalleVentaBO> DetVenta = new List<DetalleVentaBO>();
            foreach (DataRow detalles in result.Rows)
            {
                var DetVentBo = new DetalleVentaBO();
                DetVentBo.IdVenta = detalles[0].ToString();
                DetVentBo.IdProducto = detalles[1].ToString();
                DetVentBo.NombreProd = detalles[2].ToString();
                DetVentBo.PrecioProd = Convert.ToDouble(detalles[3].ToString());
                DetVentBo.CantidadProd = Convert.ToInt32(detalles[4].ToString());
                DetVentBo.DescuentoProd = Convert.ToDouble(detalles[5].ToString());
                DetVentBo.Subtotal = Convert.ToDouble(detalles[6].ToString());
                DetVentBo.Total = Convert.ToDouble(detalles[7].ToString());
                DetVenta.Add(DetVentBo);
            }
            #endregion Datos dummy
            string DirRepor = "~/Reportes/Reportes/";
            string urlArchivo = string.Format("{0}.{1}", "DetalleVentaRepor", "rdlc");
            string FullReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirRepor), urlArchivo);
            ReportViewer reporte = new ReportViewer();
            reporte.Reset();
            reporte.LocalReport.ReportPath = FullReport;
            ReportDataSource DatosDS = new ReportDataSource("DSDetalleVenta", DetVenta);
            reporte.LocalReport.DataSources.Add(DatosDS);
            reporte.LocalReport.Refresh();
            byte[] file = reporte.LocalReport.Render("PDf");

            return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "Reporte_DetalleVenta.", "PDF"));
        }

        public ActionResult ReporteProducto()
        {
            #region Datos dummy
            string query = ("SELECT IdProducto,NombreProd,DescripcionProd,PrecioProd,DescuentoProd,CantidadDisponibleProd,CantidadMinimaProd,IdTipoProducto1,IdProveedor1,FechaRegistroProd FROM Producto WHERE StatusProd=1");
            var result = Con.TablaConnsulta(query);
            List<ProductoBO> Productos = new List<ProductoBO>();
            foreach (DataRow Pro in result.Rows)
            {
                var ProductoBO = new ProductoBO();
                ProductoBO.IdProducto = Convert.ToInt32(Pro[0].ToString());
                ProductoBO.NombreProd = Pro[1].ToString();
                ProductoBO.DescripcionProd = Pro[2].ToString();
                ProductoBO.PrecioProd = Convert.ToDouble(Pro[3].ToString());
                ProductoBO.DescuentoProd = Convert.ToDouble(Pro[4].ToString());
                ProductoBO.CantidadDisponibleProd = Convert.ToInt32(Pro[5].ToString());
                ProductoBO.CantidadMinimaProd = Convert.ToInt32(Pro[6].ToString());
                ProductoBO.IdTipoProducto1 = Convert.ToInt32(Pro[7].ToString());
                ProductoBO.IdProveedor1 = Convert.ToInt32(Pro[8].ToString());
                ProductoBO.FechaRegistroProd = Convert.ToDateTime(Pro[9].ToString());
                Productos.Add(ProductoBO);
            }
            #endregion Datos dummy
            string DirRepor = "~/Reportes/Reportes/";
            string urlArchivo = string.Format("{0}.{1}", "ProductoRepor", "rdlc");
            string FullReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirRepor), urlArchivo);
            ReportViewer reporte = new ReportViewer();
            reporte.Reset();
            reporte.LocalReport.ReportPath = FullReport;
            ReportDataSource DatosDS = new ReportDataSource("DSProducto", Productos);
            reporte.LocalReport.DataSources.Add(DatosDS);
            reporte.LocalReport.Refresh();
            byte[] file = reporte.LocalReport.Render("PDf");

            return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "Reporte_DetalleVenta.", "PDF"));
        }



    }
}