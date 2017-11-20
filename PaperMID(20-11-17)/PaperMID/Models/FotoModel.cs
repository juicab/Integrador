using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class FotoModel:Plantilla
    {
        ConexionModel oConexion;

        public FotoModel()
        {
            oConexion = new ConexionModel();
        }
        public int Agregar(object Obj)
        {
            BO.FotoBO BO = (BO.FotoBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO Foto ([ImagenFoto],[PrincipalFoto],[FechaRegistroFoto],[StatusFoto],[IdProducto1]) OUTPUT INSERTED.IdFoto VALUES(@ImagenFoto,@PrincipalFoto,@FechaRegistroFoto,@StatusFoto,@IdProducto1);");
            Cmd.Parameters.Add("@ImagenFoto", SqlDbType.Image).Value = BO.ImagenFoto;
            Cmd.Parameters.Add("@PrincipalFoto", SqlDbType.Bit).Value = BO.PrincipalFoto;
            Cmd.Parameters.Add("@FechaRegistroFoto", SqlDbType.DateTime).Value = BO.FechaRegistroFoto;
            Cmd.Parameters.Add("@StatusFoto", SqlDbType.Bit).Value = BO.StatusFoto;
            Cmd.Parameters.Add("@IdProducto1", SqlDbType.Int).Value = BO.IdProducto;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            BO.FotoBO BO = (BO.FotoBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE Foto SET StatusFoto=(@StatusFoto) WHERE IdFoto=(@IdFoto);");
            Cmd.Parameters.Add("@IdFoto", SqlDbType.Int).Value = BO.IdFoto;
            Cmd.Parameters.Add("@StatusFoto", SqlDbType.Bit).Value = BO.StatusFoto;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.FotoBO BO = (BO.FotoBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE Foto SET ImagenFoto=(@ImagenFoto), PrincipalFoto=(@PrincipalFoto) WHERE IdFoto=(@IdFoto);");
            Cmd.Parameters.Add("@IdFoto", SqlDbType.Int).Value = BO.IdFoto;
            Cmd.Parameters.Add("@ImagenFoto", SqlDbType.Image).Value = BO.ImagenFoto;
            Cmd.Parameters.Add("@PrincipalFoto", SqlDbType.Bit).Value = BO.PrincipalFoto;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return oConexion.TablaConnsulta("SELECT * FROM Foto WHERE StatusFoto=1;");
        }
    }
}