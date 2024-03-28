using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplication1.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Template/assets/vendor/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css").Include("~/Template/assets/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/style/js").Include("~/Template/assets/js/main.js"));

        }
    }
}