//using System.Web.Http;

//namespace ShopOfMusicalInstruments.Core
//{
//    public static class WebApiConfig
//    {
//        public static void Register(HttpConfiguration config)
//        {
//            // Web API configuration and services
//            config.EnsureInitialized();

//            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
//            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;


//            // Web API routes
//            //config.MapHttpAttributeRoutes();

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{action}/{id}",
//                defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional },
//                constraints: null
//            );

//            config.DependencyResolver = new DependenciesRegistry.UnityResolver(DependenciesRegistry.RegisterComponents());

//        }
//    }
//}

using System.Web.Http;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace ShopOfMusicalInstruments.Core
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API
            // Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.DependencyResolver = new DependenciesRegistry.UnityResolver(DependenciesRegistry.RegisterComponents());
        }
    }
}