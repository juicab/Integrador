using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class ProveedorBO
    {
        public int idProveedor { get; set; }
        public string NombreProv { get; set; }
        public string TelefonoProv { get; set; }
        public string CorreoProv { get; set; }
        public DateTime FechaRegistroProv { get; set; }
        public bool StatusProv { get; set; }


    }
}