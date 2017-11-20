using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperMID.BO;
using System.Data;
using System.Data.SqlClient;

namespace PaperMID.Models
{
    public class MetodoPagoModel
    {
        ConexionModel OConexion;
        public MetodoPagoModel() { OConexion = new ConexionModel(); }

        public int Agregar(object Obj)
        {
            BO.MetodoPagoBO oMetodo = (BO.MetodoPagoBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO [dbo].[MetodoPago]([TipoPago],[FechaRegistroMetPago],[StatusMetPago]) VALUES(@TipoPago,@FechaRegistroMetPago,@StatusMetPago)");
            //@TipoPago,@FechaRegistroMetPago,@StatusMetPago
            Cmd.Parameters.Add("@TipoPago", SqlDbType.VarChar).Value = oMetodo.TipoPago;
            Cmd.Parameters.Add("@FechaRegistroMetPago", SqlDbType.DateTime).Value = DateTime.Now.Date;
            Cmd.Parameters.Add("@StatusMetPago", SqlDbType.Bit).Value = 1;
            Cmd.CommandType = CommandType.Text;
            return OConexion.EjecutarSQL(Cmd);
        }
        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[MetodoPago]SET [StatusMetPago] = @StatusMetPago WHERE IdMetodoPago=@IdMetodoPago");
            Cmd.Parameters.Add("@IdMetodoPago", SqlDbType.Int).Value = Obj;
            Cmd.Parameters.Add("@StatusMetPago", SqlDbType.Bit).Value = false;
            Cmd.CommandType = CommandType.Text;
            return OConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.MetodoPagoBO Bo = (BO.MetodoPagoBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[MetodoPago]SET [TipoPago] = @TipoPago WHERE IdMetodoPago=@IdMetodoPago");
            Cmd.Parameters.Add("@IdTipoUsuario", SqlDbType.Int).Value = Bo.IdMetodoPago;
            Cmd.Parameters.Add("@TipoPago", SqlDbType.VarChar).Value = Bo.TipoPago;
            Cmd.CommandType = CommandType.Text;
            return OConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return OConexion.TablaConnsulta("Select *From MetodoPago Where StatusMetPago=1");
        }
        public MetodoPagoBO RecuperarMetPago(int Id)
        {
            var MetPago = new MetodoPagoBO();
            string BuscarTipo = string.Format("Select * From [dbo].[MetodoPago] Where IdMetodoPago=" + Id);
            DataTable Datos = OConexion.TablaConnsulta(BuscarTipo);
            DataRow Row = Datos.Rows[0];
            MetPago.IdMetodoPago = Convert.ToInt32(Row["IdTipoUsuario"]);
            MetPago.TipoPago = Row["TipoUsu"].ToString();
            return MetPago;
        }
    }
}