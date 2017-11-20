using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class TipoUsuarioBO
    {
        public int IdTipoUsuario { get; set; }
        public string TipoUsu { get; set; }
        public DateTime FechaRegistroTuser { get; set; }
        public Boolean StatusTuser { get; set; }
    }
}