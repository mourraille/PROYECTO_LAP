﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ClientUI.App_Start;
using System.Web.Configuration;

namespace ClientUI
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

            var clientID = WebConfigurationManager.AppSettings["auth0:ClientId"];
            var clientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];

            config.MessageHandlers.Add(new JsonWebTokenValidationHandler()
            {
                Audience = clientID,
                SymmetricKey = clientSecret
            });
        }
    }
}
