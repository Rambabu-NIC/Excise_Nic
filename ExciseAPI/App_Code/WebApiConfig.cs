using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ExciseAPI
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            //config.Filters.Add(new JwtAuthorizeAttribute(secretKey));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            config.Routes.MapHttpRoute(
                name: "WebFormApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Index" }
            );


        }

    }
}