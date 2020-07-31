using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RhController.Services;
using RhUI.Models.DB;

namespace RhUI
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
			services.AddDbContextPool<AppDBContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("EFDbConnection"));
            });

            services.AddRazorPages();
            //services.AddSingleton<Services.IRepository, Services.MockContainerRepository>();
            services.AddScoped<AppDBContext>();
            services.AddScoped(typeof(IProyecto<>), typeof(SQLRepository<>));
			services.AddScoped<IProyectoRepository, ContainerReposiroy>();
			//services.AddScoped<IContainerRepository, ContainerRepository>();


			services.AddRouting(option => {
                option.LowercaseUrls = true;
                option.LowercaseQueryStrings = true;
                option.AppendTrailingSlash = true;

            });




			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
				cookieOptions.LoginPath = "/";
			});

			services.AddMvc().AddRazorPagesOptions(options => {
				options.Conventions.AuthorizeFolder("/admin");
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);



			/*
			services.AddAuthentication(options =>
			{
				options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			}).AddCookie(options =>
			{
				options.LoginPath = new PathString("/Index");
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
			});

			// [Asma Khalid]: configuración de autorización.  
			services.AddMvc().AddRazorPagesOptions(options =>
			{
				options.Conventions.AuthorizeFolder("/");
				options.Conventions.AllowAnonymousToPage("/Index");
			});*/

			// [Asma Khalid]: registra el contexto de configuración de la base de datos SQL como servicios.    
			//services.AddDbContext<PROYECTOWORKContext>(opciones => opciones.UseSqlServer(Configuration.GetConnectionString("EFDbConnection")));
		}
			





		
		

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
				app.UseAuthentication();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
