using System.Web.Http;

namespace WebUI.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
            //    Newtonsoft.Json.PreserveReferencesHandling.All;

            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = 
            //    Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
            //    Newtonsoft.Json.PreserveReferencesHandling.None;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{bookId}",
                defaults: new { bookId = RouteParameter.Optional }
            );
        }
    }
}