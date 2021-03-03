using Blabber.Controllers;
using Blabber.DB;
using Blabber.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blabber
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string connectionString = "Data Source=blabber.db";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            setupDependencyInjection();
        }

        private void setupDependencyInjection()
        {
            var services = new ServiceCollection();
            configureServices(services, connectionString);
            var provider = services.BuildServiceProvider();
            var resolver = new DefaultDependencyResolver(provider);
            DependencyResolver.SetResolver(resolver);
        }

        private void configureServices(ServiceCollection services, string connectionString)
        {
            services.AddScoped((svc) => new BlabberContext("db"));
            services.AddScoped<IBlabDb>((svc) =>
                new BlabDb(svc.GetRequiredService<BlabberContext>()));
            services.AddScoped<BlabStorage>();

            // setup controllers
            services.AddTransient<BlabController>();
            services.AddTransient<HomeController>();
        }
    }
}