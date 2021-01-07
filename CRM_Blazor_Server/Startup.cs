using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Model_Library;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CRM_Blazor_Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            // TODO: Uitzoeken welke service wij moeten gebruiken. Inplaats  van "AddSingleton", kijk naar AddTransient.
            // Transient is gonna create an instance everytime we ask for one, Singleton creates one instance for the entire application.
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClientData, ClientData>();
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<IMailChimpController, MailChimpController>();
            services.AddTransient<IMailChimpListController, MailChimpListController>();
            services.AddTransient<ICampaignController, CampaignController>();
            services.AddTransient<IMailChimpTemplateController, MailChimpTemplateController>();
            //services.AddTransient<ICa>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
