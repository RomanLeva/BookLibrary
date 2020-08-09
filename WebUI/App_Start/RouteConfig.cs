using System.Web.Mvc;
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
               name: "Book",
               url: "Books/Book/{bookId}",
               defaults: new { controller = "Books", action = "Book", bookId = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Delete",
               url: "Books/Delete/{bookId}",
               defaults: new { controller = "Books", action = "Delete", bookId = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Edit",
               url: "Books/Edit/{bookId}",
               defaults: new { controller = "Books", action = "Edit", bookId = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Author",
               url: "Authors/Author/{authorId}",
               defaults: new { controller = "Authors", action = "Author", authorId = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Genre",
               url: "Genres/Genre/{genreId}",
               defaults: new { controller = "Genres", action = "Genre", genreId = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Books",
               url: "{controller}/{action}/{page}",
               defaults: new { controller = "Books", action = "Books", page = "1" }
            );
            
            routes.MapRoute(
               name: "Search",
               url: "{controller}/{action}",
               defaults: new { controller = "Books", action = "Search" }
            );

        }
    }
}
