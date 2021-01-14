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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddProtectedBrowserStorage();

            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClientData, ClientData>();
            services.AddTransient<IContactData, ContactData>();
            services.AddTransient<IUserData, UserData>();

            services.AddScoped<LoginState>();
            services.AddTransient<ILabelData, LabelData>();


            services.AddTransient<IMailChimpController, MailChimpController>();
            services.AddTransient<IMailChimpListController, MailChimpListController>();
            services.AddTransient<ICampaignController, CampaignController>();
            services.AddTransient<IMailChimpTemplateController, MailChimpTemplateController>();
            services.AddTransient<ILabelCampaignLinkData, LabelCampaignLinkData>();
            services.AddTransient<IContactCampaignLinkData, ContactCampaignLinkData>();
        }

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
