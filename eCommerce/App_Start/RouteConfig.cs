using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eCommerce
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FicheClient",
                url: "Fiche/{id}",
                defaults: new { controller = "Produit", action = "Fiche", id = UrlParameter.Optional },
                constraints: new {id = "\\d+"}
            );

            routes.MapRoute(
                name: "TirelireClient",
                url: "Tirelire/{id}",
                defaults: new { controller = "Produit", action = "Fiche", id = UrlParameter.Optional },
                constraints: new { id = "\\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
