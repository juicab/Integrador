using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace PaperMID.Models
{
    public class UsuarioModel : Plantilla
    {
        private String hashkey = "*hg849gh84th==3tg7-534d=_";

        ConexionModel oConexion;
        BO.MéthodesBO oMéthodesBO;
        public UsuarioModel()
        {
            oConexion = new ConexionModel();
            oMéthodesBO = new BO.MéthodesBO();
        }
        public int Buscar_Direccion()
        {
            SqlCommand Cmd = new SqlCommand("select max(IdDireccion) from Direccion");
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }
        public int Agregar(object Obj)
        {
            BO.UsuarioBO oBO = (BO.UsuarioBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO Usuario ([Usuario],[ContraseñaUsu],[ImagenUsu],[NombreUsu],[ApellidoPaternoUsu],[ApellidoMaternoUsu],[FechaNacimientoUsu],[TelefonoUsu],[CorreoUsu],[FechaRegistroUsu],[IdTipoUsuario1],[IdDireccion2],[StatusUsu],[SHA512]) OUTPUT INSERTED.IdUsuario VALUES(@Usuario, @ContraseñaUsu,@ImagenUsu, @NombreUsu, @ApellidoPaternoUsu, @ApellidoMaternoUsu,@FechaNacimientoUsu, @TelefonoUsu, @CorreoUsu, @FechaRegistroUsu, @IdTipoUsuario1,@IdDireccion2, @StatusUsu, @SHA512);");
            Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oBO.Usuario;
            Cmd.Parameters.Add("@ContraseñaUsu", SqlDbType.VarChar).Value = oMéthodesBO.Encriptar(oBO.ContraseñaUsu);
            Cmd.Parameters.Add("@ImagenUsu", SqlDbType.Image).Value = oBO.ImagenUsu;
            Cmd.Parameters.Add("@NombreUsu", SqlDbType.VarChar).Value = oBO.NombreUsu;
            Cmd.Parameters.Add("@ApellidoPaternoUsu", SqlDbType.VarChar).Value = oBO.ApellidoPaternoUsu;
            Cmd.Parameters.Add("@ApellidoMaternoUsu", SqlDbType.VarChar).Value = oBO.ApellidoMaternoUsu;
            Cmd.Parameters.Add("@FechaNacimientoUsu", SqlDbType.Date).Value = oBO.FechaNacimientoUsu;
            Cmd.Parameters.Add("@TelefonoUsu", SqlDbType.VarChar).Value = oBO.TelefonoUsu;
            Cmd.Parameters.Add("@CorreoUsu", SqlDbType.VarChar).Value = oBO.CorreoUsu;
            Cmd.Parameters.Add("@FechaRegistroUsu", SqlDbType.DateTime).Value = DateTime.Now;
            Cmd.Parameters.Add("@IdTipoUsuario1", SqlDbType.Int).Value = 2;
            Cmd.Parameters.Add("@IdDireccion2", SqlDbType.Int).Value = Buscar_Direccion();
            Cmd.Parameters.Add("@StatusUsu", SqlDbType.Bit).Value = true;
            Cmd.Parameters.Add("@SHA512", SqlDbType.VarChar).Value = oMéthodesBO.CreateSHAHash(oBO.Usuario,oBO.ContraseñaUsu, hashkey);
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            BO.UsuarioBO oBO = (BO.UsuarioBO)Obj;
            SqlCommand Cmd = new SqlCommand("");
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            throw new NotImplementedException();
        }

        public DataTable Mostrar()
        {
            throw new NotImplementedException();
        }
    }
}