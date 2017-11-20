using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PaperMID.BO;

namespace PaperMID.Models
{
    public class DireccionModel:Plantilla
    {
        ConexionModel oConexion;

        public DireccionModel()
        {
            oConexion = new ConexionModel();
        }
        public int Agregar(object Obj)
        {
            BO.DireccionBO BO = (BO.DireccionBO)Obj;
            string comple = (BO.CalleDir + " Num. int " + BO.NumInteDir + " Num ext." + BO.NumExteDir + " por " + BO.CruzaDir + " " + BO.ColoniaDir + " " + BO.CPDir);
            SqlCommand Cmd = new SqlCommand("INSERT INTO Direccion ([CalleDir],[NumInteDir],[NumExteDir],[CruzaDir],[ColoniaDir],[CPDir],[UbicacionDir],[LatitudDir],[LongitudDir],[IdMunicipio1],[FechaRegistroDir],[StatusDir],[completo]) OUTPUT INSERTED.IdDireccion VALUES(@CalleDir,@NumInteDir,@NumExteDir,@CruzaDir,@ColoniaDir,@CPDir,@UbicacionDir,@LatitudDir,@LongitudDir,@IdMunicipio1,@FechaRegistroDir,@StatusDir,@completo);");
            Cmd.Parameters.Add("@CalleDir", SqlDbType.VarChar).Value = BO.CalleDir;
            Cmd.Parameters.Add("@NumInteDir", SqlDbType.VarChar).Value = BO.NumInteDir;
            Cmd.Parameters.Add("@NumExteDir", SqlDbType.VarChar).Value = BO.NumExteDir;
            Cmd.Parameters.Add("@CruzaDir", SqlDbType.VarChar).Value = BO.CruzaDir;
            Cmd.Parameters.Add("@ColoniaDir", SqlDbType.VarChar).Value = BO.ColoniaDir;
            Cmd.Parameters.Add("@CPDir", SqlDbType.VarChar).Value = BO.CPDir;
            Cmd.Parameters.Add("@UbicacionDir", SqlDbType.VarChar).Value=0;
            Cmd.Parameters.Add("@LatitudDir", SqlDbType.VarChar).Value = 0;
            Cmd.Parameters.Add("@LongitudDir", SqlDbType.VarChar).Value =0;
            Cmd.Parameters.Add("@IdMunicipio1", SqlDbType.Int).Value = BO.IdMunicipio1;
            Cmd.Parameters.Add("@FechaRegistroDir", SqlDbType.DateTime).Value =DateTime.Now.Date;
            Cmd.Parameters.Add("@StatusDir", SqlDbType.Bit).Value = 1;
            Cmd.Parameters.Add("@completo", SqlDbType.VarChar).Value = comple;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            BO.DireccionBO BO = (BO.DireccionBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE Direccion SET StatusDir=(@StatusDir) WHERE IdDireccion=(@IdDireccion);");
            Cmd.Parameters.Add("@IdDireccion", SqlDbType.Int).Value = BO.IdDireccion;
            Cmd.Parameters.Add("@StatusDir", SqlDbType.Bit).Value = BO.StatusDir;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.DireccionBO BO = (BO.DireccionBO)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE Direccion SET CalleDir=(@CalleDir), NumInteDir=(@NumInteDir), NumExteDir=(@NumExteDir), CruzaDir=(@CruzaDir), ColoniaDir=(@ColoniaDir), CPDir=(@CPDir), UbicacionDir=(@UbicacionDir), LatitudDir=(@LatitudDir), LongitudDir=(@LongitudDir), IdMunicipio1=(@IdMunicipio1) WHERE IdDireccion=(@IdDireccion);");
            Cmd.Parameters.Add("@IdDireccion", SqlDbType.Int).Value = BO.IdDireccion;
            Cmd.Parameters.Add("@CalleDir", SqlDbType.VarChar).Value = BO.CalleDir;
            Cmd.Parameters.Add("@NumInteDir", SqlDbType.VarChar).Value = BO.NumInteDir;
            Cmd.Parameters.Add("@NumExteDir", SqlDbType.VarChar).Value = BO.NumExteDir;
            Cmd.Parameters.Add("@CruzaDir", SqlDbType.VarChar).Value = BO.CruzaDir;
            Cmd.Parameters.Add("@ColoniaDir", SqlDbType.VarChar).Value = BO.ColoniaDir;
            Cmd.Parameters.Add("@CPDir", SqlDbType.VarChar).Value = BO.CPDir;
            Cmd.Parameters.Add("@UbicacionDir", SqlDbType.VarChar).Value = BO.UbicacionDir;
            Cmd.Parameters.Add("@LatitudDir", SqlDbType.VarChar).Value = BO.LatitudDir;
            Cmd.Parameters.Add("@LongitudDir", SqlDbType.VarChar).Value = BO.LongitudDir;
            Cmd.Parameters.Add("@IdMunicipio1", SqlDbType.Int).Value = BO.IdMunicipio1;
            Cmd.CommandType = CommandType.Text;
            return oConexion.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return oConexion.TablaConnsulta("SELECT * FROM Direccion WHERE StatusDir=1;");
        }

        public List<MunicipioBO> ListaMunicipios()
        {
            string query = ("Select IdMunicipio,NombreMuni from Municipio Where StatusMuni=1");
            var result = oConexion.TablaConnsulta(query);
            List<MunicipioBO> listaMunicipio = new List<MunicipioBO>();
            foreach (DataRow muni in result.Rows)
            {
                var municipioBO = new MunicipioBO();
                municipioBO.IdMunicipio = int.Parse(muni[0].ToString());
                municipioBO.NombreMuni = muni[1].ToString();
                listaMunicipio.Add(municipioBO);
            }
            return listaMunicipio;

        }

        public DireccionBO Obtener_Direccion(int id)
        {
            var Direccion = new DireccionBO();
            String StrBuscar = string.Format("Select * from Direccion where IdDireccion=" + id);
            DataTable Datos = oConexion.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Direccion.IdDireccion = Convert.ToInt32(row["IdDireccion"]);
            Direccion.CalleDir = row["CalleDir"].ToString();
            Direccion.NumInteDir = row["NumInteDir"].ToString();
            Direccion.NumExteDir = row["NumExteDir"].ToString();
            Direccion.CruzaDir = row["CruzaDir"].ToString();
            Direccion.ColoniaDir = row["ColoniaDir"].ToString();
            Direccion.CPDir = row["CPDir"].ToString();
            Direccion.UbicacionDir = row["UbicacionDir"].ToString();
            Direccion.LongitudDir = row["LongitudDir"].ToString();
            Direccion.LatitudDir = row["LatitudDir"].ToString();
            Direccion.IdMunicipio1= Convert.ToInt32(row["IdMunicipio1"]);
            Direccion.FechaRegistroDir = Convert.ToDateTime(row["FechaRegistroDir"].ToString());
            Direccion.StatusDir = Convert.ToBoolean(row["StatusDir"]);
            
            return Direccion;
        }

    }
}