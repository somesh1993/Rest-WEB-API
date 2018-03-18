using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCWebAPI
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

            //routes.MapRoute(
            //    name: "Rock",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Rock", action = "GetAllTemp", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Values",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Values", action = "GetAllEmployees", id = UrlParameter.Optional }
            //);
        }
    }
}
