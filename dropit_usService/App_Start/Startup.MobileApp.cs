using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using dropit_usService.DataObjects;
using dropit_usService.Models;
using Owin;

namespace dropit_usService
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
            Database.SetInitializer(new dropit_usInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer(null);

            app.UseMobileAppAuthentication(config);
            app.UseWebApi(config);
        }
    }

    public class dropit_usInitializer : CreateDatabaseIfNotExists<dropit_usContext>
    {
        protected override void Seed(dropit_usContext context)
        {
			List<Project> todoItems = new List<Project>
            {
				new Project { Id = Guid.NewGuid().ToString(), Name = "First item" },
				new Project { Id = Guid.NewGuid().ToString(), Name = "Second item" },
            };

			foreach (Project todoItem in todoItems)
            {
				context.Set<Project>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

