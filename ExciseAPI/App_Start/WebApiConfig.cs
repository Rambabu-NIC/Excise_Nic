using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ExciseAPI
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }


        //LIVE PAYMENT URLS

        public static string paymentredirect= "https://excise.telangana.gov.in/";
        

        //LOCAL PAYMENT URLS 
        //public static string paymentredirect= "http://localhost:60403/";
    }
}
