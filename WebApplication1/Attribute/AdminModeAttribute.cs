using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication.Domain.Enums;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.BusinessLogic;
using WebApplication1.Extensions;

namespace WebApplication1.Attribute
{
    public class AdminModeAttribute:ActionFilterAttribute
    {
        private readonly ISession _sessionBusinessLogic;
        public AdminModeAttribute()
        {
            var businessLogic = new BussinesLogic();
            _sessionBusinessLogic = businessLogic.GetSessionBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
                if (profile != null && profile.Level == URole.Admin)
                {
                    HttpContext.Current.SetMySessionObject(profile);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
            }
        }
    }
}