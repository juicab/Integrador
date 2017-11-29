using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperMID.BO;
using System.Data;
using System.Data.SqlClient;

namespace PaperMID.Models
{
    public class EmpresaModel
    {
        ConexionModel oConexion;
        public EmpresaModel()
        {
            oConexion = new ConexionModel();
        }
        public int Modificar(object Obj)
        {
            BO.EmpresaBO BO = (BO.EmpresaBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[Empresa] SET [NombreEmpre] = @NombreEmpre,[MisionEmpre] = @MisionEmpre,[VisionEmpre] = @VisionEmpre,[ValoresEmpre] = @ValoresEmpre,[CorreoEmpre] = @CorreoEmpre,[TelefenoEmpre] = @TelefenoEmpre,[FacebookEmpre] = @FacebookEmpre,[IdDireccion1] = @IdDireccion1 WHERE IdEmpresa=@IdEmpresa");
            //@ImagenLogoEmpre ,@ValoresEmpre,@CorreoEmpre,@TelefenoEmpre,@FacebookEmpre,@IdDireccion1
            Cmd.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = BO.IdEmpresa;
            Cmd.Parameters.Add("@NombreEmpre", SqlDbType.VarChar).Value = BO.NombreEmpre;
            Cmd.Parameters.Add("@MisionEmpre", SqlDbType.VarChar).Value = BO.MisionEmpre;
            Cmd.Parameters.Add("@VisionEmpre", SqlDbType.VarChar).Value = BO.VisionEmpre;
            //Cmd.Parameters.Add("@ImagenMisionEmpre", SqlDbType.Image).Value = BO.ImagenMisionEmpre;
            //Cmd.Parameters.Add("@ImagenVisionEmpre", SqlDbType.Image).Value = BO.ImagenVisionEmpre;
            //Cmd.Parameters.Add("@ImagenLogoEmpre", SqlDbType.Image).Value = BO.ImagenLogoEmpre;
            Cmd.Parameters.Add("@ValoresEmpre", SqlDbType.VarChar).Value = BO.ValoresEmpre;
            Cmd.Parameters.Add("@CorreoEmpre", SqlDbType.VarChar).Value = BO.CorreoEmpre;
            Cmd.Parameters.Add("@TelefenoEmpre", SqlDbType.VarChar).Value = BO.TelefenoEmpre;
            Cmd.Parameters.Add("@FacebookEmpre", SqlDbType.VarChar).Value = BO.FacebookEmpre;
            Cmd.Parameters.Add("@IdDireccion1", SqlDbType.Int).Value = BO.IdDireccion1;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
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

        //public EmpresaBO Obtener_Direccion_Empresa(int id)
        //{
        //    var DirEmp = new DireccionBO();
        //    String StrBuscar = string.Format("Select * from Direccion where IdDireccion="+id);
        //    DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
        //    DataRow row = Datos.Rows[0];
        //    DirEmp.CalleDir =(row["IdEmpresa"]).ToString();
        //    DirEmp.NombreEmpre = row["NombreEmpre"].ToString();
        //    DirEmp.MisionEmpre = row["MisionEmpre"].ToString();
        //    DirEmp.VisionEmpre = row["VisionEmpre"].ToString();
        //    DirEmp.ValoresEmpre = row["ValoresEmpre"].ToString();
        //    DirEmp.CorreoEmpre = row["CorreoEmpre"].ToString();
        //    DirEmp.TelefenoEmpre = row["TelefenoEmpre"].ToString();
        //    DirEmp.FacebookEmpre = row["FacebookEmpre"].ToString();
        //    DirEmp.IdDireccion1 = Convert.ToInt32(row["IdDireccion1"]);
        //    DirEmp.FechaRegistroEmpre = Convert.ToDateTime(row["FechaRegistroEmpre"].ToString());
        //    DirEmp.StatusEmpre = Convert.ToBoolean(row["StatusEmpre"]);
        //    return DirEmp;
        //}

        public EmpresaBO Obtener_NombreUser(int id)
        {
            var Empresa = new EmpresaBO();
            String StrBuscar = string.Format("Select NombreUsu from Usuario where IdUsuario="+id);
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Empresa.nombreusuario = row["NombreUsu"].ToString();
            return Empresa;
        }

    }
}