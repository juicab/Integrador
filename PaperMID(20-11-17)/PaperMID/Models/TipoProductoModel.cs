using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PaperMID.BO;
using System.Data;

namespace PaperMID.Models
{
    public class TipoProductoModel
    {
        ConexionModel Con;
        public TipoProductoModel() { Con = new ConexionModel(); }

        public int Agregar(object Obj)
        {
            BO.TipoProductoBO oTipo = (BO.TipoProductoBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO [dbo].[TipoProducto] ([TipoProd],[FechaRegistroTpro],[StatusTpro]) Values (@TipoProd,@FechaRegistroTpro,@StatusTpro);");
            Cmd.Parameters.Add("@TipoProd", SqlDbType.VarChar).Value = oTipo.TipoProducto;
            Cmd.Parameters.Add("@FechaRegistroTpro", SqlDbType.DateTime).Value = DateTime.Now;
            Cmd.Parameters.Add("@StatusTpro", SqlDbType.Bit).Value = 1;
            Cmd.CommandType = CommandType.Text;
            return Con.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {

            SqlCommand Cmd = new SqlCommand("Update [dbo].[TipoProducto] Set [StatusTpro]=@StatusTpro Where IdTipoProducto =@IdTipoProducto;");
            Cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = Obj;
            Cmd.Parameters.Add("@StatusTpro", SqlDbType.Bit).Value = false;
            Cmd.CommandType = CommandType.Text;
            return Con.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.TipoProductoBO Bo = (BO.TipoProductoBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE TipoProducto SET TipoProd=(@TipoProd) WHERE IdTipoProducto=(@IdTipoProducto);");
            Cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = Bo.IdTipoProducto;
            Cmd.Parameters.Add("@TipoProd", SqlDbType.VarChar).Value = Bo.TipoProducto;
            Cmd.CommandType = CommandType.Text;
            return Con.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return Con.TablaConnsulta("Select *From TipoProducto Where StatusTpro=1");
        }
        public TipoProductoBO RecuperarTipo(int Id)
        {
            var tPro = new TipoProductoBO();
            string BuscarTipo = string.Format("Select * From [dbo].[TipoProducto] Where IdTipoProducto=" + Id);
            DataTable Datos = Con.TablaConnsulta(BuscarTipo);
            DataRow Row = Datos.Rows[0];
            tPro.IdTipoProducto = Convert.ToInt32(Row["IdTipoProducto"]);
            tPro.TipoProducto = Row["TipoProd"].ToString();
            tPro.Fecha_Reg = Convert.ToDateTime(Row["FechaRegistroTpro"].ToString());
            return tPro;


        }
    }
}