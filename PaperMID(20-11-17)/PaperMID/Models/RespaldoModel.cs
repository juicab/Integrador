using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PaperMID.Models
{
    public class RespaldoModel
    {
        ConexionModel oConexion;
        public RespaldoModel()
        {
            oConexion = new ConexionModel();
        }
        public void Respaldo()
        {
            string nombre_copia = (System.DateTime.Today.Day.ToString() + "-" + System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Year.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString() + " PaperMidResp");
            string Comando_Consulta = "BACKUP DATABASE [Integrador] TO  DISK = N'C:\\" + nombre_copia + ".bak' WITH NOFORMAT, NOINIT,  NAME = N'Integrador-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlCommand cmd = new SqlCommand(Comando_Consulta, oConexion.EstablecerConexion());
            oConexion.AbrirConexion();
            cmd.ExecuteNonQuery();
            oConexion.CerrarConexion();
            oConexion.EstablecerConexion().Dispose();
        }



    }
}