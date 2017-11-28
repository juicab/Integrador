using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PaperMID.BO;

namespace PaperMID.Models
{
    public class MunicipioModel:Plantilla
    {
        ConexionModel oConexion;
        public int IdEstado1;
        public MunicipioModel()
        {
            oConexion = new ConexionModel();
        }
        public int Agregar(object Obj)
        {
            BO.MunicipioBO BO = (BO.MunicipioBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO Municipio ([NombreMuni],[IdEstado1],[FechaRegistroMuni],[StatusMuni]) OUTPUT INSERTED.IdMunicipio VALUES (@NombreMuni,@IdEstado1,@FechaRegistroMuni,@StatusMuni);");
            Cmd.Parameters.Add("@NombreMuni", SqlDbType.VarChar).Value = BO.NombreMuni;
            Cmd.Parameters.Add("@IdEstado1", SqlDbType.Int).Value = BO.IdEstado1;
            Cmd.Parameters.Add("@FechaRegistroMuni", SqlDbType.DateTime).Value = DateTime.Now.Date;
            Cmd.Parameters.Add("@StatusMuni", SqlDbType.Bit).Value = true;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("UPDATE Municipio SET StatusMuni=(@StatusMuni) WHERE IdMunicipio=(@IdMunicipio);");
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int).Value = Obj;
            Cmd.Parameters.Add("@StatusMuni", SqlDbType.Bit).Value = false;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.MunicipioBO BO = (BO.MunicipioBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE Municipio SET NombreMuni=(@NombreMuni), IdEstado1=(@IdEstado1) WHERE IdMunicipio=(@IdMunicipio);");
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int).Value = BO.IdMunicipio;
            Cmd.Parameters.Add("@NombreMuni", SqlDbType.VarChar).Value = BO.NombreMuni;
            Cmd.Parameters.Add("@IdEstado1", SqlDbType.Int).Value = BO.IdEstado1;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return oConexion.TablaConnsulta("SELECT IdMunicipio,NombreMuni,NombreEdo from Municipio inner join Estado on IdEstado=IdEstado1 where StatusMuni=1");
        }

        public List<EstadoBO> ListaEstado()
        {
            string query = ("Select IdEstado,NombreEdo from Estado Where StatusEdo=1");
            var result = oConexion.TablaConnsulta(query);
            List<EstadoBO> listaEstados = new List<EstadoBO>();
            foreach (DataRow estado in result.Rows)
            {
                var estadoBO = new EstadoBO();
                estadoBO.IdEstado = int.Parse(estado[0].ToString());
                estadoBO.NombreEdo = estado[1].ToString();
                listaEstados.Add(estadoBO);
            }
            return listaEstados;

        }

        public MunicipioBO Obtener_Municipio(int id)
        {
            var Municipio = new MunicipioBO();
            String StrBuscar = string.Format("Select * from Municipio where IdMunicipio=" + id);
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Municipio.IdMunicipio = Convert.ToInt32(row["IdMunicipio"]);
            Municipio.NombreMuni = row["NombreMuni"].ToString();
            Municipio.FechaRegistroMuni = Convert.ToDateTime(row["FechaRegistroMuni"].ToString());
            Municipio.StatusMuni = Convert.ToBoolean(row["StatusMuni"]);
            Municipio.IdEstado1 = Convert.ToInt32(row["IdEstado1"]);
            IdEstado1 = Convert.ToInt32(row["IdEstado1"]);
            return Municipio;
        }


    }
}