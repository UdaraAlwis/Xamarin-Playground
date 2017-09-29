using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using UdaraMyNotesAppService.DataObjects;
using UdaraMyNotesAppService.Models;
using Owin;

namespace UdaraMyNotesAppService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new UdaraMyNotesAppInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<UdaraMyNotesAppContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class UdaraMyNotesAppInitializer : CreateDatabaseIfNotExists<UdaraMyNotesAppContext>
    {
        protected override void Seed(UdaraMyNotesAppContext context)
        {
            List<MyNote> myNoteItems = new List<MyNote>
            {
                new MyNote { Id = Guid.NewGuid().ToString(), TimeStamp = DateTime.Now, Title = "First Item", Description = "First Item Description!"},
                new MyNote { Id = Guid.NewGuid().ToString(), TimeStamp = DateTime.Now, Title = "Second Item", Description = "Second Item Description!"},
            };

            foreach (MyNote myNoteItem in myNoteItems)
            {
                context.Set<MyNote>().Add(myNoteItem);
            }

            base.Seed(context);
        }
    }
}

