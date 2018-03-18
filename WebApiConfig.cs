using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVCWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Check",
                routeTemplate: "v1/{controller}/{action}",
                defaults: new { controller = "Values", action = "GetAllEmployees" }
            );

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "v2/Rock",
                defaults: new { controller = "Rock", action = "GetAllTemp" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "Values",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { controller = "Values", action = "GetAllEmployees", id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //name: "Rock",
            //routeTemplate: "api/{controller}/{action}/{id}",
            //defaults: new { controller = "Rock", action = "GetAllTemp", id = RouteParameter.Optional }
            //);
        }
    }
}
