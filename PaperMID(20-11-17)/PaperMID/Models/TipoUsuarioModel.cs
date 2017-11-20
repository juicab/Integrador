using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PaperMID.BO;
using System.Data;

namespace PaperMID.Models
{
    public class TipoUsuarioModel
    {
        ConexionModel OConexion;
        public TipoUsuarioModel() { OConexion = new ConexionModel(); }

        public int Agregar(object Obj)
        {
            BO.TipoUsuarioBO oTipo = (BO.TipoUsuarioBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO [dbo].[TipoUsuario]([TipoUsu],[FechaRegistroTuser],[StatusTuser]) VALUES(@TipoUsu,@FechaRegistroTuser,@StatusTuser)");
            //@TipoUsu,@FechaRegistroTuser,@StatusTuser
            Cmd.Parameters.Add("@TipoUsu", SqlDbType.VarChar).Value = oTipo.TipoUsu;
            Cmd.Parameters.Add("@FechaRegistroTuser", SqlDbType.DateTime).Value = DateTime.Now.Date;
            Cmd.Parameters.Add("@StatusTuser", SqlDbType.Bit).Value = 1;
            Cmd.CommandType = CommandType.Text;
            return OConexion.EjecutarSQL(Cmd);
        }
        //aqui me Quede 
        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[TipoUsuario]SET [StatusTuser] = @StatusTuser WHERE IdTipoUsuario=@IdTipoUsuario");
            Cmd.Parameters.Add("@IdTipoUsuario", SqlDbType.Int).Value = Obj;
            Cmd.Parameters.Add("@StatusTuser", SqlDbType.Bit).Value = false;
            Cmd.CommandType = CommandType.Text;
            return OConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.TipoUsuarioBO Bo = (BO.TipoUsuarioBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[TipoUsuario] SET [TipoUsu] = @TipoUsu WHERE IdTipoUsuario=@IdTipoUsuario");
            Cmd.Parameters.Add("@IdTipoUsuario", SqlDbType.Int).Value = Bo.IdTipoUsuario;
            Cmd.Parameters.Add("@TipoUsu", SqlDbType.VarChar).Value = Bo.TipoUsu;
            Cmd.CommandType = CommandType.Text;
            return OConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return OConexion.TablaConnsulta("Select *From TipoUsuario Where StatusTuser=1");
        }
        public TipoUsuarioBO RecuperarTipo(int Id)
        {
            var tUser = new TipoUsuarioBO();
            string BuscarTipo = string.Format("Select * From [dbo].[TipoUsuario] Where IdTipoUsuario=" + Id);
            DataTable Datos = OConexion.TablaConnsulta(BuscarTipo);
            DataRow Row = Datos.Rows[0];
            tUser.IdTipoUsuario = Convert.ToInt32(Row["IdTipoUsuario"]);
            tUser.TipoUsu = Row["TipoUsu"].ToString();
            return tUser;
        }
    }
}