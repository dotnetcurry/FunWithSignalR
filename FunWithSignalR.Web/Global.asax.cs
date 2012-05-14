using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FunWithSignalR;
using System.Web.WebPages;
using Elmah;

namespace FunWithSignalR
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BlogPost", action = "Index", id = UrlParameter.Optional }
            );
        }

        static void RegisterDependencies()
        {
            var root = new CompositionRoot();
            GlobalConfiguration.Configuration.ServiceResolver.SetResolver(root.DependencyResolver);
            ControllerBuilder.Current.SetControllerFactory(root.ControllerFactory);


            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iphone")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                                    ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });

        }

        protected void Application_Start()
        {
            RegisterDependencies();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.RegisterTemplateBundles();
            RegisterDependencies();
        }

        void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            if (e.Exception.Message.StartsWith(@"File does not exist"))
                e.Dismiss();
        }

    }
}