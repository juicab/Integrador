using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PaperMID.BO
{
    public class UsuarioBO
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string ContraseñaUsu { get; set; }
        public byte[] ImagenUsu { get; set; }
        public string NombreUsu { get; set; }
        public string ApellidoPaternoUsu { get; set; }
        public string ApellidoMaternoUsu { get; set; }
        public string FechaNacimientoUsu { get; set; }
        public string TelefonoUsu { get; set; }
        public string CorreoUsu { get; set; }
        public string FechaRegistroUsu { get; set; }
        public int IdTipoUsuario1 { get; set; }
        public int IdDireccion2 { get; set; }
        public Boolean StatusUsu { get; set; }
        public string SHA512 { get; set; }

        public List<TipoUsuarioBO> TiposUsuario { get; set; }
    }
}