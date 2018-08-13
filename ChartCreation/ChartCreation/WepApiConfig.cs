using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ChartCreation
{
    public class WepApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.EnableCors();
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
             defaults: new { id = RouteParameter.Optional });
        }
    }
}