using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.BO;

namespace PaperMID.Controllers
{
    public class LoginController : Controller
    {
        LoginModel oLoginModel;
        DireccionModel oDireccionModel = new DireccionModel();
        BO.LoginBO oLoginBO;
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }
    }
}