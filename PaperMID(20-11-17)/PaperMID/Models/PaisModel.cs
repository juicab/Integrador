using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PaperMID.BO;

namespace PaperMID.Models
{
    public class PaisModel:Plantilla
    {
        ConexionModel oConexion;

        public PaisModel()
        {
            oConexion = new ConexionModel();
        }
        public int Agregar(object Obj)
        {
            BO.PaisBO BO = (BO.PaisBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO Pais ([NombrePais],[FechaRegistroPais],[StatusPais]) OUTPUT INSERTED.IdPais VALUES (@NombrePais,@FechaRegistroPais,@StatusPais)");
            Cmd.Parameters.Add("@NombrePais", SqlDbType.VarChar).Value = BO.NombrePais;
            Cmd.Parameters.Add("@FechaRegistroPais", SqlDbType.DateTime).Value = DateTime.Now;
            Cmd.Parameters.Add("@StatusPais", SqlDbType.Bit).Value = 1; //Activo.
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("UPDATE Pais SET StatusPais=(@StatusPais) WHERE IdPais=(@IdPais)");
            Cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = Obj;
            Cmd.Parameters.Add("@StatusPais", SqlDbType.Bit).Value = 0; //Inactivo.
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.PaisBO BO = (BO.PaisBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE Pais SET NombrePais=(@NombrePais) WHERE IdPais=(@IdPais)");
            Cmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = BO.IdPais;
            Cmd.Parameters.Add("@NombrePais", SqlDbType.VarChar).Value = BO.NombrePais;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return oConexion.TablaConnsulta("SELECT * FROM Pais WHERE StatusPais=1"); //Todos los paises activos.
        }

        public PaisBO Obtener_Pais(int id)
        {
            var Pais = new PaisBO();
            String StrBuscar = string.Format("Select * from Pais where IdPais=" + id);
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Pais.IdPais = Convert.ToInt32(row["IdPais"]);
            Pais.NombrePais = row["NombrePais"].ToString();
            Pais.FechaRegistroPais = Convert.ToDateTime(row["FechaRegistroPais"].ToString());
            Pais.StatusPais = Convert.ToBoolean(row["StatusPais"]);
            return Pais;
        }
    }
}