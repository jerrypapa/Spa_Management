using Spa_Management.Autogen;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Spa_Management.Operations;
using Spa_Management.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using Rotativa.AspNetCore;
using Spa_Management.Interfaces.Spa;

namespace Spa_Management
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
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        

            //   RotativaConfiguration.Setup(env);

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();



            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
			{
				config.SignIn.RequireConfirmedEmail = true;
			})
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.Configure<IdentityOptions>(options =>
			{
				// Password settings
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = false;
				options.Password.RequiredUniqueChars = 6;

				// Lockout settings
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
				options.Lockout.MaxFailedAccessAttempts = 10;
				options.Lockout.AllowedForNewUsers = true;

				// User settings
				options.User.RequireUniqueEmail = true;
			});
			services.Configure<IISOptions>(options =>
			{
				// options.AutomaticAuthentication = false;
			});
			services.AddSingleton<IFileProvider>(
				new PhysicalFileProvider(
					Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddTransient<IDatabaseErrorLogger, DatabaseErrorLogger>();
			services.AddTransient<ISMSSender, SMSSender>();
			services.AddTransient<ISystemParameters, SystemParameters>();
			services.AddTransient<IRouter, Router>();
			services.AddTransient<ICurrencies, Currencies>();
			services.AddTransient<IAutoGen, AutoGen>();
			services.AddTransient<ISpaOperations, SpaOperations>();
			services.AddTransient<IDbOperations, DbOperations>();
			services.AddScoped<SendSMS>();
			services.AddScoped<AfricasTalkingGateway>();
			services.AddScoped<AfricasTalkingGatewayException>();
			services.AddScoped<insertOps>();
			services.AddMvc().AddControllersAsServices();
			services.AddTransient<CRB, CRBService>();
			services.AddScoped<IPRSDetails>();
			//services.AddMvc().AddRazorPagesOptions(options =>
			//{
			//    options.Conventions.AddPageRoute("/Account/Login", "");
			//});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();

			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
            RotativaConfiguration.Setup(env);
            app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

            

        }
        
	}
}
