using System.Web.Mvc;
using System.Web.Routing;

namespace SellingWS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                "Default",
                "",
                new { controller = "Help", action = "Index" },
                new[] { "SellingWS.Areas.HelpPage.Controllers" }
            ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });

        }
    }
}