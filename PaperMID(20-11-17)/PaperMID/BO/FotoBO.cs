using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class FotoBO
    {
        public int IdFoto { get; set; }
        public byte[] ImagenFoto { get; set; }
        public bool PrincipalFoto { get; set; }
        public DateTime FechaRegistroFoto { get; set; }
        public Boolean StatusFoto { get; set; }
        public int IdProducto { get; set; }
    }
}