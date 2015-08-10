using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChessLandPrj
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
            routes.MapRoute("getprov",
                "Account/GetProvibyCountryId/",
                new { controller = "acc", action = "GetProvibyCountryId" },
                new[] { "MIDP.Controller" });
            routes.MapRoute("getcity",
                "Account/GetCityByProvId/",
                new { controller = "acc", action = "GetCityByProvId" },
                new[] { "MIDP.Controller" });

        }
    }
}