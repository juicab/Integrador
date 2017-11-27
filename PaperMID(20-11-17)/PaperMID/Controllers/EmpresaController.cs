using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        EmpresaModel oEmpresa = new EmpresaModel();
        EmpresaBO oEmpresaBO;
        public ActionResult ActualizarEmpresa()
        {
            return View(oEmpresa.Obtener_Empresa(1));
        }

        public ActionResult ActuaDatosEmpre(EmpresaBO oEmpre, HttpPostedFileBase ImagenMision, HttpPostedFileBase ImagenVision,HttpPostedFileBase ImagenLogo)
        {
            oEmpre = new EmpresaBO();
            oEmpresaBO = new EmpresaBO();
            if(ImagenMision!=null && ImagenMision.ContentLength > 0)
            {
                oEmpresaBO.ImagenMisionEmpre = new byte[ImagenMision.ContentLength];
                ImagenMision.InputStream.Read(oEmpresaBO.ImagenMisionEmpre, 0, ImagenMision.ContentLength);
            }
            else
            {
                oEmpresaBO.ImagenMisionEmpre = null;
            }
            if (ImagenVision != null && ImagenVision.ContentLength > 0)
            {
                oEmpresaBO.ImagenVisionEmpre = new byte[ImagenVision.ContentLength];
                ImagenVision.InputStream.Read(oEmpresaBO.ImagenVisionEmpre, 0, ImagenVision.ContentLength);
            }
            else
            {
                oEmpresaBO.ImagenVisionEmpre = null;
            }
            if (ImagenLogo != null && ImagenLogo.ContentLength > 0)
            {
                oEmpresaBO.ImagenLogoEmpre = new byte[ImagenLogo.ContentLength];
                ImagenLogo.InputStream.Read(oEmpresaBO.ImagenLogoEmpre, 0, ImagenLogo.ContentLength);
            }
            else
            {
                oEmpresaBO.ImagenLogoEmpre = null;
            }
            oEmpresa.Modificar(oEmpre);
            ActualizarEmpresa();
            return View("ActualizarEmpresa");
        }
    }
}