using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace PaperMID.Models
{
    public class LoginModel
    {
        public int IdUsuario = 0;
        public String Usuario, Modulo;
        public Byte[] ImagenUsu;
        private String hashkey = "*hg849gh84th==3tg7-534d=_";

        ConexionModel oConexion;
        BO.LoginBO oLoginBO;
        BO.MéthodesBO oMéthodes;
        public LoginModel()
        {
            oConexion = new ConexionModel();
            oMéthodes = new BO.MéthodesBO();
            oLoginBO = new BO.LoginBO();
        }
        public void BuscarUsuario(BO.LoginBO oLoginBO)
        {
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Vst_Login WHERE Usuario=(@Usuario) AND ContraseñaUsu=(@ContraseñaUsu) AND SHA512=(@SHA512) AND StatusUsu=(@StatusUsu);", oConexion.EstablecerConexion());
            Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oLoginBO.Usuario; 
            Cmd.Parameters.Add("@ContraseñaUsu", SqlDbType.VarChar).Value = oMéthodes.Encriptar(oLoginBO.ContraseñaUsu);
            Cmd.Parameters.Add("@SHA512", SqlDbType.VarChar).Value = oMéthodes.CreateSHAHash(oLoginBO.Usuario,oLoginBO.ContraseñaUsu, hashkey);
            Cmd.Parameters.Add("@StatusUsu", SqlDbType.Bit).Value = true;
            Cmd.CommandType = CommandType.Text;

            oConexion.AbrirConexion();

            SqlDataReader Datos = Cmd.ExecuteReader();

            while (Datos.Read())
            {
                IdUsuario = int.Parse(Datos[0].ToString());
                Usuario = Datos[1].ToString();
                try
                {
                    ImagenUsu = (byte[])Datos[4];
                }
                catch(Exception)
                {
                    ImagenUsu = null;
                }
               
                Modulo = Datos[5].ToString();
            }
            oConexion.CerrarConexion();
        }
        public bool Comprobacion()
        {
            if (IdUsuario != 0)
            {
                oLoginBO.IdUsuario = IdUsuario;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}