using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class PromocionesBO
    {
        public int IdPromo { get; set; }
        public string NombrePromo { get; set; }
        public string DescripcionPromo { get; set; }
        public string FechaInicioPromo { get; set; }
        public string FechaFinPromo { get; set; }
        public int IdProve { get; set; }
        public DateTime FechaRegistroPromo { get; set; }
        public Boolean StatusPromo { get; set; }
        public List<ProveedorBO> Proveedores { get; set; }
    }
}