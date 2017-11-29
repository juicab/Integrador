using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class EmpresaBO
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpre { get; set; }
        public string MisionEmpre { get; set; }
        public string VisionEmpre { get; set; }
        public byte[] ImagenMisionEmpre { get; set; }
        public byte[] ImagenVisionEmpre { get; set; }
        public byte[] ImagenLogoEmpre { get; set; }
        public string ValoresEmpre { get; set; }
        public string CorreoEmpre { get; set; }
        public string TelefenoEmpre { get; set; }
        public string FacebookEmpre { get; set; }
        public int IdDireccion1 { get; set; }
        public DateTime FechaRegistroEmpre { get; set; }
        public Boolean StatusEmpre { get; set; }

        public string nombreusuario { get; set; }
    }
}