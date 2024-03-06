using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Model u = new Model();
            u.Username = "Customer";
            u.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };

            return View(u);
        }

        public ActionResult Product()
        {
            var product = Request.QueryString["p"];

            Model u = new Model();
            u.Username = "Customer";
            u.SingleProduct = product;

            return View();
        }

        [HttpPost]
        public ActionResult Product(string btn)

        {
            return RedirectToAction("Product", "Home", new { @p = btn });
        }


    }
    public class RegisterController : Controller
    {
        private readonly ISession _session;
        public RegisterController()
        {
            var bl = new BussinessLogic();
            _session = bl.GetSessionBL();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult LogIn(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credentials = login.Credentials,
                    Password = login.Password,
                    LogInIP = login.LogInIP,
                    LogInDateTime = DateTime.Now
                };

                ULogInResponce resp = _session.UserLoginAction(data);
                if (resp.Status)
                {
                    //Add Cookie

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", resp.ActionStatusMsg);
                    return View();
                }
            }

            return View();
        }
    }
}