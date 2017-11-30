using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperMID.BO;
using System.Data.SqlClient;
using System.Data;


namespace PaperMID.Models
{
    public class PromocionesModel
    {
        ConexionModel con;
        public int IdProveedor1;
        public PromocionesModel() { con = new ConexionModel(); }


        public int Agregar(object Obj)
        {
            BO.PromocionesBO oPo = (BO.PromocionesBO)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO [dbo].[Promociones] ([NombrePromo],[DescripcionPromo],[FechaInicioPromo],[FechaFinPromo],[IdProveedor1],[FechaRegistroPromo],[StatusPromo]) VALUES (@NombrePromo,@DescripcionPromo,@FechaInicioPromo,@FechaFinPromo,@IdProveedor1,@FechaRegistroPromo,@StatusPromo);");
            Cmd.Parameters.Add("@NombrePromo", SqlDbType.VarChar).Value = oPo.NombrePromo;
            Cmd.Parameters.Add("@DescripcionPromo", SqlDbType.VarChar).Value = oPo.DescripcionPromo;
            Cmd.Parameters.Add("@FechaInicioPromo", SqlDbType.Date).Value = oPo.FechaInicioPromo;
            Cmd.Parameters.Add("@FechaFinPromo", SqlDbType.Date).Value = oPo.FechaFinPromo;
            Cmd.Parameters.Add("@IdProveedor1", SqlDbType.Int).Value = oPo.IdProve;
            Cmd.Parameters.Add("@FechaRegistroPromo", SqlDbType.DateTime).Value = DateTime.Now;
            Cmd.Parameters.Add("@StatusPromo", SqlDbType.Bit).Value = true;
            Cmd.CommandType = CommandType.Text;
            return con.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("Update [dbo].[Promociones] Set [StatusPromo]=(@StatusPromo) Where IdPromocion =(@IdPromocion);");
            Cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = Obj;
            Cmd.Parameters.Add("@StatusPromo", SqlDbType.Bit).Value = false;
            Cmd.CommandType = CommandType.Text;
            return con.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            BO.PromocionesBO Bo = (BO.PromocionesBO)Obj;
            SqlCommand Cmd = new SqlCommand("Update [dbo].[Promociones] Set [NombrePromo]=(@NombrePromo), [DescripcionPromo]=(@DescripcionPromo),[FechaInicioPromo]=(@FechaInicioPromo),[FechaFinPromo]=(@FechaFinPromo),[IdProveedor1]=(@IdProveedor1) Where IdPromocion=@IdPromocion");
            Cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = Bo.IdPromo;
            Cmd.Parameters.Add("@NombrePromo", SqlDbType.VarChar).Value = Bo.NombrePromo;
            Cmd.Parameters.Add("@DescripcionPromo", SqlDbType.VarChar).Value = Bo.DescripcionPromo;
            Cmd.Parameters.Add("@FechaInicioPromo", SqlDbType.Date).Value = Bo.FechaInicioPromo;
            Cmd.Parameters.Add("@FechaFinPromo", SqlDbType.Date).Value = Bo.FechaFinPromo;
            Cmd.Parameters.Add("@IdProveedor1", SqlDbType.Int).Value = Bo.IdProve;
            return con.EjecutarSQL(Cmd);
        }

        public DataTable Mostrar()
        {
            return con.TablaConnsulta("Select * From Promociones Where StatusPromo=1;");
        }
        public PromocionesBO RecuperarPromo(int Id)
        {
            var Promo = new PromocionesBO();
            string BuscarPromo = String.Format("SELECT * FROM Promociones WHERE IdPromocion='{0}'", Id);
            DataTable Datos = con.TablaConnsulta(BuscarPromo);
            DataRow Row = Datos.Rows[0];
            Promo.IdPromo = Convert.ToInt32(Row["IdPromocion"]);
            Promo.NombrePromo = Row["NombrePromo"].ToString();
            Promo.DescripcionPromo = Row["DescripcionPromo"].ToString();
            Promo.FechaInicioPromo = Row["FechaInicioPromo"].ToString();
            Promo.FechaFinPromo = Row["FechaFinPromo"].ToString();
            Promo.IdProve = Convert.ToInt32(Row["IdProveedor1"].ToString());
            IdProveedor1= Convert.ToInt32(Row["IdProveedor1"].ToString());
            return Promo;
        }
        //metedo para llenar DropDownList
        public List<ProveedorBO> ListaProveedor()
        {
            string query = ("Select IdProveedor,NombreProv from Proveedor Where StatusProv=1");
            var result = con.TablaConnsulta(query);
            List<ProveedorBO> ListProveedores = new List<ProveedorBO>();
            foreach (DataRow Proveedor in result.Rows)
            {
                var ProveBo = new ProveedorBO();
                ProveBo.idProveedor = int.Parse(Proveedor[0].ToString());
                ProveBo.NombreProv = Proveedor[1].ToString();
                ListProveedores.Add(ProveBo);
            }
            return ListProveedores;
        }
    }
}