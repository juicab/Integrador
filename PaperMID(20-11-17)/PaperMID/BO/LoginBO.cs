using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaperMID.BO
{
    public class LoginBO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese el Usuario")]
        [StringLength(50)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Ingrese la Contraseña")]
        [StringLength(100)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string ContraseñaUsu { get; set; }  
    }
}