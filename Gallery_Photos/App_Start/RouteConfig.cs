using System.Web.Mvc;
using System.Web.Routing;

namespace Gallery_Photos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RouteExistingFiles = true;

            routes.MapRoute(
              name: "GetImage",
              url: "img/{id}.jpg",
              defaults: new { controller = "Home", action = "GetImage", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}