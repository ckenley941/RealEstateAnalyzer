using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RealEstateAnalyzer.Emailing;
using RealEstateAnalyzer.Notifications;
using RealEstateAnalyzer.Notifications.Processes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateAnalyzer.Models.Database;
using Microsoft.EntityFrameworkCore;
using RealEstateAnalyzer.Export;

namespace RealEstateAnalyzer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RealEstateAnalyzerContext>(options => {
                options.UseSqlServer("Server=.\\SQLExpress;Database=RealEstateAnalyzer;Trusted_Connection=True;", providerOptions => providerOptions.CommandTimeout(60));
                });

            services.Configure<Microsoft.Extensions.Hosting.HostOptions>(option =>
            {
                option.ShutdownTimeout = TimeSpan.FromSeconds(20);
            });
            services.Configure<EmailSettings>(_configuration.GetSection("EmailSettings"));

            services.AddHostedService<NotificationService>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IDataExporter, DataExporter>();
            services.AddSingleton<INotificationDispatcher, NotificationDispatcher>();
            services.AddSingleton<INotificationContainer, NotificationContainer>();
            services.AddSingleton<ISendIncidentReport, SendIncidentReport>();
            services.AddSingleton<IGetHousingData, GetHousingData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            string environmentName = EnvironmentName.Development;
            if (!Debugger.IsAttached || env.IsProduction())
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                Directory.SetCurrentDirectory(pathToContentRoot);
                environmentName = EnvironmentName.Production;
            }
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
