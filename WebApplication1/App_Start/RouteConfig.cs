using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }    

    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Template/assets/vendor/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css").Include("~/Template/assets/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/style/js").Include("~/Template/assets/js/main.js"));

        }
    }

}

