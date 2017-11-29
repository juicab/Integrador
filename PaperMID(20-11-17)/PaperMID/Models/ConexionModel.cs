using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class ConexionModel
    {
        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataAdapter Adaptador;
        DataTable TablaVirtual;
        DataSet DAtaSetAdaptador;

        String Lugo = "Data Source=LUGO\\LUGO;Initial Catalog=Integrador;Integrated Security=True";
        String Uicab = "Data Source=DESKTOP-E7KBKHQ;Initial Catalog=Integrador;Integrated Security=True";
        String Heredia = "Data Source=FSOCIETY; Initial Catalog=Integrador; Integrated Security=True";
        public SqlConnection EstablecerConexion()
        {
            Con = new SqlConnection(Uicab);
            return Con;
        }

        public void AbrirConexion()
        {
            Con.Open();
        }

        public void CerrarConexion()
        {
            Con.Close();
        }

        public int EjecutarSQL(string Sentencia)
        {
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = EstablecerConexion();
                AbrirConexion();
                Cmd.CommandText = Sentencia;
                int Confirmacion = Cmd.ExecuteNonQuery();
                CerrarConexion();
                return 1;
            }
            catch (SqlException)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public int EjecutarSQL(SqlCommand SqlComando)
        {
            //try
            //{
            //    // INSERT, DELETE, UPDATE
            //    Cmd = new SqlCommand();
            //    Cmd = SqlComando;
            //    Cmd.Connection = this.EstablecerConexion();
            //    this.AbrirConexion();
            //    int id = 0; id = Convert.ToInt32(Cmd.ExecuteScalar());
            //    this.CerrarConexion();
            //    return id;
            //}
            //catch (SqlException)
            //{
            //    return 0;
            //}
            //finally
            //{
            //    CerrarConexion();
            //}
            Cmd = new SqlCommand();
            Cmd = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            int id = 0; id = Convert.ToInt32(Cmd.ExecuteScalar());
            this.CerrarConexion();
            return id;
        }

        public DataTable TablaConnsulta(string Sentencia)
        {
            Adaptador = new SqlDataAdapter(Sentencia, EstablecerConexion());
            TablaVirtual = new DataTable();

            //Rellenar un objeto DataSet con los resultados del elemento SelectCommand.
            Adaptador.Fill(TablaVirtual);
            return TablaVirtual;
        }


        public DataSet EjecutarSentencia(SqlCommand SqlComando)
        {

            // SELECT (Devolver registros)
            Adaptador = new SqlDataAdapter();
            Cmd = new SqlCommand();
            DAtaSetAdaptador = new DataSet();

            Cmd = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            Adaptador.SelectCommand = Cmd;
            Adaptador.Fill(DAtaSetAdaptador);
            this.CerrarConexion();
            return DAtaSetAdaptador;

        }

        public DataSet EjecutarSentencia_string(string SqlComando)
        {

            // SELECT (Devolver registros)
            Adaptador = new SqlDataAdapter();
            Cmd = new SqlCommand();
            DAtaSetAdaptador = new DataSet();

            Cmd.CommandText = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            Adaptador.SelectCommand = Cmd;
            Adaptador.Fill(DAtaSetAdaptador);
            this.CerrarConexion();
            return DAtaSetAdaptador;

        }

    }
}