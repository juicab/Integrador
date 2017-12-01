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
        public int IdDireccion2;
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
        public int Buscar_Datos_Direccion(String IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SELECT IdDireccion2 FROM Usuario WHERE IdUsuario=(@IdUsuario)");
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Convert.ToInt32(IdUsuario);
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }
        public int Agregar(object Obj)
        {
            BO.UsuarioBO oBO = (BO.UsuarioBO)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Usuario @Usuario, @ContraseñaUsu,@ImagenUsu, @NombreUsu, @ApellidoPaternoUsu, @ApellidoMaternoUsu,@FechaNacimientoUsu, @TelefonoUsu, @CorreoUsu, @IdTipoUsuario1,@IdDireccion2, @SHA512");
            Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oBO.Usuario;
            Cmd.Parameters.Add("@ContraseñaUsu", SqlDbType.VarChar).Value = oMéthodesBO.Encriptar(oBO.ContraseñaUsu);
            Cmd.Parameters.Add("@ImagenUsu", SqlDbType.Image).Value = oBO.ImagenUsu;
            Cmd.Parameters.Add("@NombreUsu", SqlDbType.VarChar).Value = oBO.NombreUsu;
            Cmd.Parameters.Add("@ApellidoPaternoUsu", SqlDbType.VarChar).Value = oBO.ApellidoPaternoUsu;
            Cmd.Parameters.Add("@ApellidoMaternoUsu", SqlDbType.VarChar).Value = oBO.ApellidoMaternoUsu;
            Cmd.Parameters.Add("@FechaNacimientoUsu", SqlDbType.Date).Value = oBO.FechaNacimientoUsu;
            Cmd.Parameters.Add("@TelefonoUsu", SqlDbType.VarChar).Value = oBO.TelefonoUsu;
            Cmd.Parameters.Add("@CorreoUsu", SqlDbType.VarChar).Value = oBO.CorreoUsu;
            Cmd.Parameters.Add("@IdTipoUsuario1", SqlDbType.Int).Value = 2;
            Cmd.Parameters.Add("@IdDireccion2", SqlDbType.Int).Value = Buscar_Direccion();
            Cmd.Parameters.Add("@SHA512", SqlDbType.VarChar).Value = oMéthodesBO.CreateSHAHash(oBO.Usuario,oBO.ContraseñaUsu, hashkey);
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Usuario @IdUsuario");
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Convert.ToInt32(Obj);
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.UsuarioBO oBO = (BO.UsuarioBO)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Usuario @IdUsuario, @Usuario, @ContraseñaUsu,@ImagenUsu, @NombreUsu, @ApellidoPaternoUsu, @ApellidoMaternoUsu,@FechaNacimientoUsu, @TelefonoUsu, @CorreoUsu, @IdTipoUsuario1,@IdDireccion2, @SHA512");
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oBO.IdUsuario;
            Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oBO.Usuario;
            Cmd.Parameters.Add("@ContraseñaUsu", SqlDbType.VarChar).Value = oMéthodesBO.Encriptar(oBO.ContraseñaUsu);
            Cmd.Parameters.Add("@ImagenUsu", SqlDbType.Image).Value = oBO.ImagenUsu;
            Cmd.Parameters.Add("@NombreUsu", SqlDbType.VarChar).Value = oBO.NombreUsu;
            Cmd.Parameters.Add("@ApellidoPaternoUsu", SqlDbType.VarChar).Value = oBO.ApellidoPaternoUsu;
            Cmd.Parameters.Add("@ApellidoMaternoUsu", SqlDbType.VarChar).Value = oBO.ApellidoMaternoUsu;
            Cmd.Parameters.Add("@FechaNacimientoUsu", SqlDbType.Date).Value = oBO.FechaNacimientoUsu;
            Cmd.Parameters.Add("@TelefonoUsu", SqlDbType.VarChar).Value = oBO.TelefonoUsu;
            Cmd.Parameters.Add("@CorreoUsu", SqlDbType.VarChar).Value = oBO.CorreoUsu;
            Cmd.Parameters.Add("@IdTipoUsuario1", SqlDbType.Int).Value = oBO.IdTipoUsuario1;
            Cmd.Parameters.Add("@IdDireccion2", SqlDbType.Int).Value = Buscar_Direccion();
            Cmd.Parameters.Add("@SHA512", SqlDbType.VarChar).Value = oMéthodesBO.CreateSHAHash(oBO.Usuario, oBO.ContraseñaUsu, hashkey);
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return oConexion.TablaConnsulta("SELECT * FROM Usuario WHERE IdUsuario <>1;");
        }
        public BO.UsuarioBO Obtener_Usuario(String IdUsuario)
        {
            var _Usuario = new BO.UsuarioBO();
            String StrBuscar = string.Format("SELECT * FROM Usuario WHERE IdUsuario='{0}'",Convert.ToInt32(IdUsuario));
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            _Usuario.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
            _Usuario.Usuario = row["Usuario"].ToString();
            //_Usuario.ContraseñaUsu = oMéthodesBO.Encriptar(row["ContraseñaUsu"].ToString());
            _Usuario.ImagenUsu = (byte[])row["ImagenUsu"];
            _Usuario.NombreUsu = row["NombreUsu"].ToString();
            _Usuario.ApellidoPaternoUsu = row["ApellidoPaternoUsu"].ToString();
            _Usuario.ApellidoMaternoUsu = row["ApellidoMaternoUsu"].ToString();
            _Usuario.FechaNacimientoUsu = row["FechaNacimientoUsu"].ToString();
            _Usuario.TelefonoUsu = row["TelefonoUsu"].ToString();
            _Usuario.CorreoUsu = row["CorreoUsu"].ToString();
            _Usuario.IdTipoUsuario1 = Convert.ToInt32(row["IdTipoUsuario1"].ToString());
            _Usuario.IdDireccion2 = Convert.ToInt32(row["IdDireccion2"]);
            IdDireccion2 = Convert.ToInt32(row["IdDireccion2"]);
            return _Usuario;
        }
        public BO.DireccionBO Obtener_Direccion_Usuario()
        {
            var _Direccion = new BO.DireccionBO();
            String StrBuscar = String.Format("SELECT * FROM Direccion WHERE IdDireccion='{0}'",IdDireccion2);
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow Row = Datos.Rows[0];
            _Direccion.IdDireccion = Convert.ToInt32(Row["IdDireccion"].ToString());
            _Direccion.CalleDir = Row["CalleDir"].ToString();
            _Direccion.ColoniaDir = Row["ColoniaDir"].ToString();
            _Direccion.CPDir = Row["CPDir"].ToString();
            _Direccion.CruzaDir = Row["CruzaDir"].ToString();
            _Direccion.NumExteDir = Row["NumExteDir"].ToString();
            _Direccion.NumInteDir = Row["NumInteDir"].ToString();
            _Direccion.IdMunicipio1 = Convert.ToInt32(Row["IdMunicipio1"].ToString());
            return _Direccion;
        }

        public List<BO.TipoUsuarioBO> Lista_Tipo_Usuario()
        {
            string Query = ("SELECT IdTipoUsuario,TipoUsu FROM TipoUsuario WHERE StatusTuser=1 AND IdTipoUsuario<>2;");
            var Result = oConexion.TablaConnsulta(Query);
            List<BO.TipoUsuarioBO> List_Tipo_Producto = new List<BO.TipoUsuarioBO>();
            foreach (DataRow Tipo_Producto in Result.Rows)
            {
                var oTipoUsuarioBO = new BO.TipoUsuarioBO();
                oTipoUsuarioBO.IdTipoUsuario= int.Parse(Tipo_Producto[0].ToString());
                oTipoUsuarioBO.TipoUsu= Tipo_Producto[1].ToString();
                List_Tipo_Producto.Add(oTipoUsuarioBO);
            }
            return List_Tipo_Producto;
        }
    }
}