using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Attribute;

namespace WebApplication1.Controllers
{
    public class AdminController : BaseController
    {
        [AdminMode]
        public ActionResult Admin()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}