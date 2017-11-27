using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PaperMID.BO;

namespace PaperMID.Models
{
    public class ProductoModel
    {
        public int IdTipoProducto1, IdProveedor1;
        public string Sentencia;
        ConexionModel oConexion;
        public ProductoModel()
        {
            oConexion = new ConexionModel();
        }
        public int Agregar(object Obj)
        {
            BO.ProductoBO _oProductoBO = (BO.ProductoBO)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Producto @CódigoProd, @NombreProd,@DescripcionProd,@PrecioProd,@DescuentoProd,@CantidadDisponibleProd,@CantidadMinimaProd,@IdTipoProducto1,@IdProveedor1");
            Cmd.Parameters.Add("@CódigoProd", SqlDbType.VarChar).Value = _oProductoBO.CódigoProd;
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
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Producto @CódigoProd");
            Cmd.Parameters.Add("@CódigoProd", SqlDbType.VarChar).Value = Obj;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);

        }

        public int Modificar(object Obj)
        {
            BO.ProductoBO _oProductoBO = (BO.ProductoBO)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Producto @CódigoProd,@NombreProd,@DescripcionProd,@PrecioProd,@DescuentoProd,@CantidadDisponibleProd,@CantidadMinimaProd,@IdTipoProducto1,@IdProveedor1");
            //Cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = _oProductoBO.IdProducto;
            Cmd.Parameters.Add("@CódigoProd", SqlDbType.VarChar).Value = _oProductoBO.CódigoProd;
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

        public DataTable Mostrar(String Filtro_IdTipoProducto1,String Filtro_IdProveedor1)
        {
            if (Filtro_IdProveedor1!=null&&Filtro_IdTipoProducto1!=null)
            {
                Sentencia = String.Format("SELECT * FROM Producto WHERE StatusProd = 1 AND IdProveedor1='{0}' AND IdTipoProducto1='{1}'",Convert.ToInt32(Filtro_IdProveedor1),Convert.ToInt32(Filtro_IdTipoProducto1));
            }
            else
            {
                Sentencia = "SELECT * FROM Producto WHERE StatusProd = 1";
            }
            return oConexion.TablaConnsulta(Sentencia);
        }

        public DataTable MostrarRep()
        {
            Sentencia = "Select * from Vst_Producto_1 where StatusProd=1";
            return oConexion.TablaConnsulta(Sentencia);
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

        public BO.ProductoBO Recuperar_Datos_Producto(String _CódigoProd)
        {
            var _Producto = new BO.ProductoBO();
            DataTable Datos = oConexion.TablaConnsulta(String.Format("SELECT * FROM Vst_Producto_1 WHERE CódigoProd='{0}' AND StatusProd='{1}'", _CódigoProd, true));
            DataRow Row = Datos.Rows[0];
            _Producto.CódigoProd = Row["CódigoProd"].ToString();
            _Producto.NombreProd = Row["NombreProd"].ToString();
            _Producto.DescripcionProd = Row["DescripcionProd"].ToString();
            _Producto.PrecioProd = Convert.ToDouble(Row["PrecioProd"]);
            _Producto.DescuentoProd = Convert.ToDouble(Row["DescuentoProd"]);
            _Producto.CantidadDisponibleProd = Convert.ToInt32(Row["CantidadDisponibleProd"]);
            _Producto.CantidadMinimaProd = Convert.ToInt32(Row["CantidadMinimaProd"]);
            _Producto.IdTipoProducto1 = Convert.ToInt32(Row["IdTipoProducto1"]);
            IdTipoProducto1= Convert.ToInt32(Row["IdTipoProducto1"]);  //Para returnar el valor en el DropDownList
            _Producto.IdProveedor1 = Convert.ToInt32(Row["IdProveedor1"]);
            IdProveedor1=Convert.ToInt32(Row["IdProveedor1"]); //Para returnar el valor en el DropDownList
            _Producto.Foto = (byte[])Row["ImagenFoto"];
            return _Producto;
        }

        public int Buscar_IdProducto(String _CódigoProd)
        {
            SqlCommand Cmd = new SqlCommand("SELECT IdProducto FROM Producto WHERE CódigoProd=@CódigoProd");
            Cmd.Parameters.Add("@CódigoProd", SqlDbType.VarChar).Value = _CódigoProd;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

    }
}