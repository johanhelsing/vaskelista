using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vaskelista
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Root",
                url: "",
                defaults: new { controller = "Household", action = "Create"}
            );

            routes.MapRoute(
                name: "Household",
                url: "Household/{action}/{id}",
                defaults: new { controller = "Household", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HouseholdWithToken",
                url: "{householdToken}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
