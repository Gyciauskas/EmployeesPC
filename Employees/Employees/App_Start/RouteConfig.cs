using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Employees
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "employees-list",
                url: "employees",
                defaults: new { controller = "Employees", action = "List" }
            );

            routes.MapRoute(
                name: "employees-create",
                url: "employees/new",
                defaults: new { controller = "Employees", action = "Create" }
            );

            routes.MapRoute(
                name: "employee-edit",
                url: "employees/{id}",
                defaults: new { controller = "Employees", action = "Update" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
