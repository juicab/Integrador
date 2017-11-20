using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class MetodoPagoBO
    {
        public int IdMetodoPago { get; set; }
        public string TipoPago { get; set; }
        public DateTime FechaRegistroMetPago { get; set; }
        public Boolean StatusMetPago { get; set; }
    }
}