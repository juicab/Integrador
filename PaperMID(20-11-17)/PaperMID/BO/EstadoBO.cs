using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class EstadoBO
    {
        public int IdEstado { get; set; }
        public string NombreEdo { get; set; }
        public int IdPais1 { get; set; }
        public DateTime FechaRegistroEdo { get; set; }
        public bool StatusEdo { get; set; }

        public List<PaisBO> paises { get; set; }
    }
}