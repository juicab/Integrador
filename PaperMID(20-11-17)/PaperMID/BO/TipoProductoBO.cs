using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class TipoProductoBO
    {
        public int IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public DateTime Fecha_Reg { get; set; }
        public Boolean Status { get; set; }
    }
}