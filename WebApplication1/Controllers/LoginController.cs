using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller 
    {


        private readonly ISession _session;

        public LoginController()
        
        {
            var bl = new BussinesLogic.BussinesLogic();
            _session = bl.GetSession();

          
        }
        
        public ActionResult Index()
        {
            return view();

        }

        [HttpPost]

        public ActionResult Index(UserLogIn data)
        {

            var uData = new ULoginData
            {
                Credential = data.Credential,
                Password = data.Password,
                IP = "0.0.0.0"
                LoginTime = DateTime .Now,

            }
            ULoginResponce resp = _session.UserLoginAction(uData);


            return view();

        } 



        public ActionResult Register()
        {

            return View();

        }
    }
}