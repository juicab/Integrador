using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class DetalleVentaBO
    {
        public string IdVenta { get; set; }
        public string IdProducto { get; set; }
        public string NombreProd { get; set; }
        public double PrecioProd { get; set; }
        public int CantidadProd { get; set; }
        public double DescuentoProd { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
    }
}