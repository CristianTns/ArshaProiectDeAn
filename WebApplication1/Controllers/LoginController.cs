using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.Responces;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller 
    {


        private readonly ISession _session;

        public LoginController()
        
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();

          
        }
        
        public ActionResult Index()
        {
            return View();

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(UserLogIn data)
        //{

        //    var uData = new ULoginData
        //    {
        //        Credential = data.Credential,
        //        Password = data.Password,
        //        Ip = "0.0.0.0",
        //        LoginTime = DateTime.Now,

        //    };
        //    ULoginResponce resp = _session.UserLoginAction(uData);


        //    return View();

        //} 



        public ActionResult Register()
        {

            return View();

        }
    }
}