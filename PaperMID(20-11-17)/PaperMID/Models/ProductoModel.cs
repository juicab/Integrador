using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PaperMID.BO;

namespace PaperMID.Models
{
    public class ProductoModel : Plantilla
    {
        ConexionModel oConexion;
        public ProductoModel()
        {
            oConexion = new ConexionModel();
        }
        public int Agregar(object Obj)
        {
            BO.ProductoBO _oProductoBO = (BO.ProductoBO)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Producto @NombreProd,@DescripcionProd,@PrecioProd,@DescuentoProd,@CantidadDisponibleProd,@CantidadMinimaProd,@IdTipoProducto1,@IdProveedor1");
            Cmd.Parameters.Add("@NombreProd", SqlDbType.VarChar).Value = _oProductoBO.NombreProd;
            Cmd.Parameters.Add("@DescripcionProd", SqlDbType.VarChar).Value = _oProductoBO.DescripcionProd;
            Cmd.Parameters.Add("@PrecioProd", SqlDbType.Float).Value = _oProductoBO.PrecioProd;
            Cmd.Parameters.Add("@DescuentoProd", SqlDbType.Float).Value = _oProductoBO.DescuentoProd;
            Cmd.Parameters.Add("@CantidadDisponibleProd", SqlDbType.Int).Value = _oProductoBO.CantidadDisponibleProd;
            Cmd.Parameters.Add("@CantidadMinimaProd", SqlDbType.Int).Value = _oProductoBO.CantidadMinimaProd;
            Cmd.Parameters.Add("@IdTipoProducto1", SqlDbType.Int).Value = _oProductoBO.IdTipoProducto1;
            Cmd.Parameters.Add("@IdProveedor1", SqlDbType.Int).Value = _oProductoBO.IdProveedor1;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Producto @IdProducto");
            Cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Convert.ToInt32(Obj);
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);

        }

        public int Modificar(object Obj)
        {
            BO.ProductoBO _oProductoBO = (BO.ProductoBO)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Producto @IdProducto,@NombreProd,@DescripcionProd,@PrecioProd,@DescuentoProd,@CantidadDisponibleProd,@CantidadMinimaProd,@IdTipoProducto1,@IdProveedor1");
            Cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = _oProductoBO.IdProducto;
            Cmd.Parameters.Add("@NombreProd", SqlDbType.VarChar).Value = _oProductoBO.NombreProd;
            Cmd.Parameters.Add("@DescripcionProd", SqlDbType.VarChar).Value = _oProductoBO.DescripcionProd;
            Cmd.Parameters.Add("@PrecioProd", SqlDbType.Float).Value = _oProductoBO.PrecioProd;
            Cmd.Parameters.Add("@DescuentoProd", SqlDbType.Float).Value = _oProductoBO.DescuentoProd;
            Cmd.Parameters.Add("@CantidadDisponibleProd", SqlDbType.Int).Value = _oProductoBO.CantidadDisponibleProd;
            Cmd.Parameters.Add("@CantidadMinimaProd", SqlDbType.Int).Value = _oProductoBO.CantidadMinimaProd;
            Cmd.Parameters.Add("@IdTipoProducto1", SqlDbType.Int).Value = _oProductoBO.IdTipoProducto1;
            Cmd.Parameters.Add("@IdProveedor1", SqlDbType.Int).Value = _oProductoBO.IdProveedor1;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return oConexion.TablaConnsulta("SELECT * FROM Producto WHERE StatusProd=1");
        }

        //Métodos para llenar DropDownList
        public List<ProveedorBO> Lista_Proveedor()
        {
            string query = ("SELECT IdProveedor,NombreProv from Proveedor WHERE StatusProv=1");
            var result = oConexion.TablaConnsulta(query);
            List<ProveedorBO> ListProveedores = new List<ProveedorBO>();
            foreach (DataRow Proveedor in result.Rows)
            {
                var ProveBo = new ProveedorBO();
                ProveBo.idProveedor = int.Parse(Proveedor[0].ToString());
                ProveBo.NombreProv = Proveedor[1].ToString();
                ListProveedores.Add(ProveBo);
            }
            return ListProveedores;
        }

        public List<TipoProductoBO> Lista_Tipo_Producto()
        {
            string Query = ("SELECT IdTipoProducto,TipoProd FROM TipoProducto WHERE StatusTpro=1");
            var Result = oConexion.TablaConnsulta(Query);
            List<TipoProductoBO> List_Tipo_Producto = new List<TipoProductoBO>();
            foreach (DataRow Tipo_Producto in Result.Rows)
            {
                var oTipoProductoBO = new TipoProductoBO();
                oTipoProductoBO.IdTipoProducto = int.Parse(Tipo_Producto[0].ToString());
                oTipoProductoBO.TipoProducto = Tipo_Producto[1].ToString();
                List_Tipo_Producto.Add(oTipoProductoBO);
            }
            return List_Tipo_Producto;
        }
    }
}