using PaperMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace PaperMID.Models
{
    public class ProveedorModel : Plantilla
    {
        ConexionModel Con;

        public ProveedorModel() { Con = new ConexionModel(); }

        public int Agregar(object Obj)
        {
            BO.ProveedorBO Bo = (BO.ProveedorBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO [dbo].[Proveedor]([NombreProv],[TelefonoProv],[CorreoProv],[FechaRegistroProv],[StatusProv]) OUTPUT INSERTED.IdProveedor VALUES (@NomProv, @TelProv, @CorreoProv, @FecRegProv,@StaProv);");
            Cmd.Parameters.Add("@NomProv", SqlDbType.VarChar).Value = Bo.NombreProv;
            Cmd.Parameters.Add("@TelProv", SqlDbType.VarChar).Value = Bo.TelefonoProv;
            Cmd.Parameters.Add("@CorreoProv", SqlDbType.VarChar).Value = Bo.CorreoProv;
            Cmd.Parameters.Add("@FecRegProv", SqlDbType.DateTime).Value = DateTime.Now;
            Cmd.Parameters.Add("@StaProv", SqlDbType.Bit).Value = true;
            Cmd.CommandType = CommandType.Text;
            return Con.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[Proveedor] SET [StatusProv]=@StaProv WHERE IdProveedor =@IDProv;");
            Cmd.Parameters.Add("@IDProv", SqlDbType.Int).Value =Obj;
            Cmd.Parameters.Add("@StaProv", SqlDbType.VarChar).Value = false;
            Cmd.CommandType = CommandType.Text;
            return Con.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.ProveedorBO Bo = (BO.ProveedorBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[Proveedor] SET [NombreProv] =(@NombreProv),[TelefonoProv] = (@TelefonoProv),[CorreoProv] = (@CorreoProv) WHERE IdProveedor=(@IdProve);");
            Cmd.Parameters.Add("@IdProve", SqlDbType.Int).Value = Bo.idProveedor;
            Cmd.Parameters.Add("@NombreProv", SqlDbType.VarChar).Value = Bo.NombreProv;
            Cmd.Parameters.Add("@TelefonoProv", SqlDbType.VarChar).Value = Bo.TelefonoProv;
            Cmd.Parameters.Add("@CorreoProv", SqlDbType.VarChar).Value = Bo.CorreoProv;
            Cmd.CommandType = CommandType.Text;
            return Con.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return Con.TablaConnsulta("Select * From [dbo].[Proveedor] Where StatusProv=1;");
        }

        public ProveedorBO Recuperar_Proveedor(int id)
        {
            var Prove = new ProveedorBO();
            string ProBusc = string.Format("Select * From Proveedor Where IdProveedor=" + id);
            DataTable Datos = Con.TablaConnsulta(ProBusc);
            DataRow Row = Datos.Rows[0];
            Prove.idProveedor = Convert.ToInt32(Row["IdProveedor"]);
            Prove.NombreProv = Row["NombreProv"].ToString();
            Prove.TelefonoProv = Row["TelefonoProv"].ToString();
            Prove.CorreoProv = Row["CorreoProv"].ToString();
            Prove.FechaRegistroProv = Convert.ToDateTime(Row["FechaRegistroProv"].ToString());
            Prove.StatusProv = Convert.ToBoolean(Row["StatusProv"]);
            return Prove;

        }

        


    }
}