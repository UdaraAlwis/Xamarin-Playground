using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;
using XFSimpleDiDemo.Services;
using XFSimpleDiDemo.ViewModel;
using XFSimpleDiDemo.Views;

namespace XFSimpleDiDemo
{
    /// <summary>
    /// Article:
    /// https://montemagno.com/add-asp-net-cores-dependency-injection-into-xamarin-apps-with-hostbuilder/
    /// </summary>
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static App Init(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream("XFSimpleDiDemo.appsettings.json"))
            {
                var host = new HostBuilder().ConfigureHostConfiguration(c =>
                {
                    // tell host configuration where to find the file
                    c.AddCommandLine(new string[] {$"ContentRoot={FileSystem.AppDataDirectory}"});
                    // read the configuration file
                    c.AddJsonStream(stream);

                }).ConfigureServices((c, x) =>
                {
                    // configure our local services and access the host configuration
                    nativeConfigureServices(c, x);
                    ConfigureServices(c, x);

                }).ConfigureLogging(l => l.AddConsole(o =>
                {
                    o.DisableColors = true;

                })).Build();

                ServiceProvider = host.Services;
            }

            return ServiceProvider.GetService<App>();
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            // Services registration
            if (ctx.HostingEnvironment.IsDevelopment())
            {
                services.AddSingleton<IDataService, MockDataService>();
            }
            else
            {
                services.AddSingleton<IDataService, DataService>();
            }

            // ViewModels registration
            services.AddTransient<MainPageViewModel>();

            // Views registration
            services.AddTransient<MainPage>();

            // TEST: access variables from appsettings.json file
            var world = ctx.Configuration["Hello"];

            services.AddHttpClient();

            services.AddSingleton<App>();
        }
    }
}
