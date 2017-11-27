using PaperMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class EstadoModel
    {
        ConexionModel oConexion;
        public int IdPais1;
        public EstadoModel()
        {
            oConexion = new ConexionModel();
        }
        public int Agregar(object Obj)
        {
            BO.EstadoBO BO = (BO.EstadoBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO Estado ([NombreEdo],[IdPais1],[FechaRegistroEdo],[StatusEdo]) OUTPUT INSERTED.IdEstado VALUES(@NombreEdo,@IdPais1,@FechaRegistroEdo,@StatusEdo);");
            Cmd.Parameters.Add("@NombreEdo", SqlDbType.VarChar).Value = BO.NombreEdo;
            Cmd.Parameters.Add("@IdPais1", SqlDbType.Int).Value = BO.IdPais1;
            Cmd.Parameters.Add("@FechaRegistroEdo", SqlDbType.DateTime).Value = DateTime.Now;
            Cmd.Parameters.Add("@StatusEdo", SqlDbType.Bit).Value = 1;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("Delete from Estado where IdEstado=" + Obj);
            Cmd.Parameters.Add("@IdEstado", SqlDbType.Int).Value = Obj;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.EstadoBO BO = (BO.EstadoBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE Estado SET NombreEdo=(@NombreEdo), IdPais1=(@IdPais1) WHERE IdEstado=(@IdEstado);");
            Cmd.Parameters.Add("@IdEstado", SqlDbType.Int).Value = BO.IdEstado;
            Cmd.Parameters.Add("@NombreEdo", SqlDbType.VarChar).Value = BO.NombreEdo;
            Cmd.Parameters.Add("@IdPais1", SqlDbType.Int).Value = BO.IdPais1;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return oConexion.TablaConnsulta("SELECT IdEstado,NombreEdo,NombrePais FROM Estado inner join pais on Pais.IdPais=Estado.IdPais1 where StatusEdo=1");
        }

        public List<PaisBO> ListaPais()
        {
            string query = ("Select IdPais,NombrePais from Pais Where StatusPais=1");
            var result = oConexion.TablaConnsulta(query);
            List<PaisBO> listaPaises = new List<PaisBO>();
            foreach (DataRow pais in result.Rows)
            {
                var paisBO = new PaisBO();
                paisBO.IdPais = int.Parse(pais[0].ToString());
                paisBO.NombrePais = pais[1].ToString();
                listaPaises.Add(paisBO);
            }
            return listaPaises;

        }

        public EstadoBO Obtener_Estado(int id)
        {
            var Estado = new EstadoBO();
            String StrBuscar = string.Format("Select * from Estado where IdEstado=" + id);
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Estado.IdEstado = Convert.ToInt32(row["IdEstado"]);
            Estado.NombreEdo = row["NombreEdo"].ToString();
            Estado.FechaRegistroEdo = Convert.ToDateTime(row["FechaRegistroEdo"].ToString());
            Estado.StatusEdo = Convert.ToBoolean(row["StatusEdo"]);
            Estado.IdPais1 = Convert.ToInt32(row["IdPais1"]);
            IdPais1= Convert.ToInt32(row["IdPais1"]);
            return Estado;
        }

    }
}