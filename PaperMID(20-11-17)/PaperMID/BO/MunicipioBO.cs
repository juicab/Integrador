using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class MunicipioBO
    {
        public int IdMunicipio { get; set; }
        public string NombreMuni { get; set; }
        public int IdEstado1 { get; set; }
        public DateTime FechaRegistroMuni { get; set; }
        public Boolean StatusMuni { get; set; }
        public List<EstadoBO> Estados { get; set; }
    }
}