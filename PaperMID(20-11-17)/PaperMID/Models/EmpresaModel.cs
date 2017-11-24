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
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[Empresa] SET [NombreEmpre] = @NombreEmpre,[MisionEmpre] = @MisionEmpre,[VisionEmpre] = @VisionEmpre,[ImagenMisionEmpre] = @ImagenMisionEmpre,[ImagenVisionEmpre] = @ImagenVisionEmpre,[ImagenLogoEmpre] = @ImagenLogoEmpre,[ValoresEmpre] = @ValoresEmpre,[CorreoEmpre] = @CorreoEmpre,[TelefenoEmpre] = @TelefenoEmpre,[FacebookEmpre] = @FacebookEmpre,[IdDireccion1] = @IdDireccion1 WHERE IdEmpresa=@IdEmpresa");
            //@ImagenLogoEmpre ,@ValoresEmpre,@CorreoEmpre,@TelefenoEmpre,@FacebookEmpre,@IdDireccion1
            Cmd.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = BO.IdEmpresa;
            Cmd.Parameters.Add("@NombreEmpre", SqlDbType.VarChar).Value = BO.NombreEmpre;
            Cmd.Parameters.Add("@MisionEmpre", SqlDbType.VarChar).Value = BO.MisionEmpre;
            Cmd.Parameters.Add("@VisionEmpre", SqlDbType.VarChar).Value = BO.VisionEmpre;
            Cmd.Parameters.Add("@ImagenMisionEmpre", SqlDbType.Image).Value = BO.ImagenMisionEmpre;
            Cmd.Parameters.Add("@ImagenVisionEmpre", SqlDbType.Image).Value = BO.ImagenVisionEmpre;
            Cmd.Parameters.Add("@ImagenLogoEmpre", SqlDbType.Image).Value = BO.ImagenLogoEmpre;
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
            Empresa.CorreoEmpre = row["CorreoEmpre"].ToString();
            Empresa.TelefenoEmpre = row["TelefenoEmpre"].ToString();
            Empresa.FacebookEmpre = row["FacebookEmpre"].ToString();
            Empresa.IdDireccion1 = Convert.ToInt32(row["IdDireccion1"]);
            Empresa.FechaRegistroEmpre = Convert.ToDateTime(row["FechaRegistroEmpre"].ToString());
            Empresa.StatusEmpre = Convert.ToBoolean(row["StatusEmpre"]);
            return Empresa;
        }

        public DireccionBO Obtener_Direccion_Empresa(int id)
        {
            var DirEmp = new DireccionBO();
            String StrBuscar = string.Format("Select * from Direccion where IdDireccion="+id);
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            DirEmp.CalleDir =(row["IdEmpresa"]).ToString();
            DirEmp.NumExteDir = row["NombreEmpre"].ToString();
            DirEmp.NumInteDir = row["MisionEmpre"].ToString();
            DirEmp.CruzaDir = row["VisionEmpre"].ToString();
            DirEmp.CPDir = row["ValoresEmpre"].ToString();
            DirEmp.ColoniaDir = row["CorreoEmpre"].ToString();
            DirEmp.IdMunicipio1 = Convert.ToInt32(row["TelefenoEmpre"]);
            return DirEmp;
        }
    }
}