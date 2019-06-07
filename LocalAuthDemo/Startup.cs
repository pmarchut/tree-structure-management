using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LocalAuthDemo.Contexts;
using LocalAuthDemo.Models;
using LocalAuthDemo.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalAuthDemo
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INodeService, NodeService>();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<LocalAuthDemoContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = $"/Account/Login";
                    options.LogoutPath = $"/Account/Logout";
                    options.AccessDeniedPath = $"/Account/AccessDenied";
                });

            services.AddDefaultIdentity<User>().AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<LocalAuthDemoContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<User> userManager)
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
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();

            SeedAdmin(userManager);
        }

        public void SeedAdmin(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync(Configuration["AppSettings:AdminUserEmail"]).Result == null)
            {
                User user = new User
                {
                    UserName = Configuration["AppSettings:UserName"],
                    Email = Configuration["AppSettings:UserEmail"],
                    NodeId = 1
                };

                IdentityResult result = userManager.CreateAsync(user, Configuration["AppSettings:UserPassword"]).Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}
