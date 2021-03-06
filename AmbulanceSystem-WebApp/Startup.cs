﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Services;

using AmbulanceSystem_WebApp.Services.Core;
using AmbulanceSystem_WebApp.Services.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmbulanceSystem_WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider();


            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            //services.Configure<CookiePolicyOptions>(options =>
            //{


            //    This lambda determines whether user consent for non - essential cookies is needed for a given request.
            //     options.CheckConsentNeeded = context => true;
            //     options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddHttpContextAccessor();

            services.AddScoped<IHttpClientService, HttpClientService>();
            services.AddHttpClient("Api",
                c => c.BaseAddress = new Uri(StaticBaseUrl.BaseUrl));
            services.AddScoped<IRecieptionistService, RecieptionistService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthorityService, AuthorityService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPatientService,PatientService>();
            services.AddScoped<IParamedicService, ParamedicService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IHospitalService, HospitalService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
