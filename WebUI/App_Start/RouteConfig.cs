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
            //routes.MapHttpRoute устанавливает сопоставления запроса некоторому маршруту для ресурса Web API
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Books",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Books", action = "Books", id = "1" }
            );
            routes.MapRoute(
               name: "Search",
               url: "{controller}/{action}",
               defaults: new { controller = "Books", action = "Search" }
            );
            
            
        }
    }
}
