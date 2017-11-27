using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperMID.BO;
using System.Data;
using System.Data.SqlClient;

namespace PaperMID.Models
{
    public class PublicoModel
    {
        ConexionModel oConexion;
        public PublicoModel()
        {
            oConexion = new ConexionModel();
        }
        public EmpresaBO Obtener_Empresa(int id)
        {
            var Empresa = new EmpresaBO();
            String StrBuscar = string.Format("Select * from Empresa where IdEmpresa= 1");
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Empresa.IdEmpresa = Convert.ToInt32(row["IdEmpresa"]);
            Empresa.NombreEmpre = row["NombreEmpre"].ToString();
            Empresa.MisionEmpre = row["MisionEmpre"].ToString();
            Empresa.VisionEmpre = row["VisionEmpre"].ToString();
            Empresa.ValoresEmpre = row["ValoresEmpre"].ToString();
            try
            {
                Empresa.ImagenMisionEmpre = (byte[])row["ImagenMisionEmpre"];
            }
            catch
            {
                Empresa.ImagenMisionEmpre = null;
            }
            try
            {
                Empresa.ImagenVisionEmpre = (byte[])row["ImagenVisionEmpre"];
            }
            catch
            {
                Empresa.ImagenVisionEmpre = null;
            }
            try
            {
                Empresa.ImagenLogoEmpre = (byte[])row["ImagenLogoEmpre"];
            }
            catch
            {
                Empresa.ImagenLogoEmpre = null;
            }
            Empresa.CorreoEmpre = row["CorreoEmpre"].ToString();
            Empresa.TelefenoEmpre = row["TelefenoEmpre"].ToString();
            Empresa.FacebookEmpre = row["FacebookEmpre"].ToString();
            Empresa.IdDireccion1 = Convert.ToInt32(row["IdDireccion1"]);
            Empresa.FechaRegistroEmpre = Convert.ToDateTime(row["FechaRegistroEmpre"].ToString());
            Empresa.StatusEmpre = Convert.ToBoolean(row["StatusEmpre"]);
            return Empresa;
        }

    }
}