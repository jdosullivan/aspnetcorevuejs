using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using GroupClue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GroupClue.Models;
using Microsoft.AspNetCore.SpaServices.Webpack;
using GroupClue.Services;
using GroupClue.Web.ModelBuilders;
using Microsoft.WindowsAzure.Storage;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Diagnostics;

namespace GroupClue.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAzureServices(this IServiceCollection services, string storageAccountConnectionString)
        {
            if (!string.IsNullOrEmpty(storageAccountConnectionString)) {
                services.AddSingleton(CloudStorageAccount.Parse(storageAccountConnectionString));
            }
            services.AddTransient<ICloudClientWrapper, CloudClientWrapper>();
            services.AddTransient<IImageRepository, ImageBlobRepository>();
            services.AddTransient<IImageService, ImageService>();

            return services;
        }

        public static IServiceCollection RegisterModelBuilders(this IServiceCollection services)
        {
            services.AddTransient<IGroupModelBuilder, GroupModelBuilder>();
            return services;
        }

        public static IServiceCollection RegisterEmailServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            return services;
        }
    }

    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("ConnectionString: " + Configuration["API_URL"]);
            services.AddSingleton<IConfiguration>(sp => { return Configuration; });
            
            var connectionString = Configuration["Database:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            // Register the OpenIddict services, including the default Entity Framework stores.
            services.AddOpenIddict<ApplicationDbContext>()
                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                .AddMvcBinders()

                // Enable the token endpoint.
                .EnableTokenEndpoint("/api/connect/token")
                .EnableUserinfoEndpoint("/api/account/userinfo")

                // Enable the password and the refresh token flows.
                .AllowPasswordFlow()
                .AllowRefreshTokenFlow()
               
                .SetAccessTokenLifetime(TimeSpan.FromSeconds(8))
                .SetRefreshTokenLifetime(TimeSpan.FromDays(32)) //1 week

                // During development, you can disable the HTTPS requirement.
                .DisableHttpsRequirement()

                // Register a new ephemeral key, that is discarded when the application
                // shuts down. Tokens signed using this key are automatically invalidated.
                // This method should only be used during development.
                .AddEphemeralSigningKey();

            // Set an application wide limit on number of unique keys (ex: key1=value1&key2=value2) that are
            // posted in a 'application/x-www-form-urlencoded' or 'multipart/form-data' request.
            // These options are used by the FormFeature.
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 10;
                options.MultipartBodyLengthLimit = 2 * 1024 * 1024;
            });

            // Add framework services.
            services.AddMvc();
         
            // Add application services.
            services.RegisterEmailServices();
            services.RegisterAzureServices(Configuration["Azure:StorageAccountConnectionString"]);
            services.RegisterModelBuilders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                // options.Lockout.MaxFailedAccessAttempts = 10;
                
                // User settings
                options.User.RequireUniqueEmail = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add a middleware used to validate access
            // tokens and protect the API endpoints.
            app.UseOAuthValidation();

            app.UseOpenIddict();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
