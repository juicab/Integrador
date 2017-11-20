using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperMID.Models
{
    interface Plantilla
    {
        int Agregar(object Obj);
        int Eliminar(object Obj);
        int Modificar(object Obj);
        DataTable Mostrar();
    }
}
