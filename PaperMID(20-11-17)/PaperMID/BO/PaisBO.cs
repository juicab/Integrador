using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class PaisBO
    {
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
        public DateTime FechaRegistroPais { get; set; }
        public Boolean StatusPais { get; set; }
    }       
}