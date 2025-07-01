﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fendahl_Frm_Training_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //new default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Registration", action = "Index", id = UrlParameter.Optional }
            );

            // Custom route for PersonController
            //routes.MapRoute(
            //name: "ProfileRoute",
            //url: "profile/{action}/{id}",
            //defaults: new { controller = "Profiles", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
