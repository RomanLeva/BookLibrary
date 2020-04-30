using System.Web.Mvc;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebUI
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
            routes.MapRoute(
               name: "Search",
               url: "{controller}/{action}",
               defaults: new { controller = "Books", action = "Search" }
            );
            routes.MapRoute(
               name: "Book",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Books", action = "Book", id = "id" }
            );
            
        }
    }
}
