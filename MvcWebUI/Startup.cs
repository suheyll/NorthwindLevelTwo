using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MvcWebUI.Helpers;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication;

namespace MvcWebUI
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
            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IProductDal, EfProductDal>();
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICartService, CartManager>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<IJobService, JobManager>();
            services.AddSingleton<IJobDal, EfJobDal>();
            services.AddSingleton<ICertService, CertManager>();
            services.AddSingleton<ICertDal, EfCertDal>();
            services.AddSingleton<IUserCertService, UserCertManager>();
            services.AddSingleton<IUserCertDal, EfUserCertDal>();
            services.AddScoped<ICartSessionHelper, CartSessionHelper>();
            services.AddScoped<ILoginSessionHelper, LoginSessionHelper>();
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            services.AddSession();
            //services.AddAuthentication("CookieAuthentication")
            //    .AddCookie("CookieAuthentication", config =>
            //    {
            //        config.Cookie.Name = "UserLoginCookie";
            //        config.LoginPath = "/Login/Index";
            //        config.AccessDeniedPath = "/Login/UserAccessDenied";
            //        config.ExpireTimeSpan = TimeSpan.FromDays(1); //session 1 gün sonra logout olacak
            //    });

            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
              .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
            {
                options.Authority = options.Authority + "/v2.0/";

                // Per the code below, this application signs in users in any Work and School
                // accounts and any Microsoft Personal Accounts.
                // If you want to direct Azure AD to restrict the users that can sign-in, change 
                // the tenant value of the appsettings.json file in the following way:
                // - only Work and School accounts => 'organizations'
                // - only Microsoft Personal accounts => 'consumers'
                // - Work and School and Personal accounts => 'common'

                // If you want to restrict the users that can sign-in to only one tenant
                // set the tenant value in the appsettings.json file to the tenant ID of this
                // organization, and set ValidateIssuer below to true.

                // If you want to restrict the users that can sign-in to several organizations
                // Set the tenant value in the appsettings.json file to 'organizations', set
                // ValidateIssuer, above to 'true', and add the issuers you want to accept to the
                // options.TokenValidationParameters.ValidIssuers collection
                options.TokenValidationParameters.ValidateIssuer = false;
            });


            services.AddControllersWithViews()
                .AddFluentValidation(option => option.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));


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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
