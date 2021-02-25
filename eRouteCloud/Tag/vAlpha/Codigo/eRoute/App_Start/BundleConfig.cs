using System.Web;
using System.Web.Optimization;

namespace eRoute
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-1.11.3.js",
                    "~/Scripts/knockout-3.0.0.js",
                    "~/Scripts/jquery-ui-1.11.4.js"
                    ));
                    //"~/Scripts/jquery-{version}.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.min.js",
                      "~/Scripts/angular-route.min.js",
                      "~/Scripts/angular-animate.min.js",
                      "~/Scripts/angular-messages.min.js",
                      "~/Scripts/angular-aria.min.js",
                      "~/Scripts/angular-material.min.js",
                      "~/Scripts/angular-resource.min.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/angular-material.min.css",
                      "~/Content/css/site.css",
                      "~/Content/css/font-awesome.min.css"));
                      //"~/Content/css/politespace.css",
                      //"~/Content/css/libs.css"));

            //bundles.Add(new StyleBundle("~/bundles/politespace").Include(
            //          "~/Scripts/politespace.js",
            //          "~/Scripts/politespace-init.js"));
        }
    }
}
