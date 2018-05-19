using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using ProjectAPI.Ioc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjectAPI.Identity.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI
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
            var config = Configuration.GetSection("ApplicationSettings").Get<AppSettings>();

            //Adding appSettings.json and binding it to AppSettings POCO class
            //Later on you can use IOptions<AppSettings> appSettings to inject it using using Microsoft.Extensions.Options;
            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddDbContext<AppDbContext>(options => options.UseMySql(config.DbConnectionString, b => b.MigrationsAssembly("ProjectAPI")));

            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new HeaderApiVersionReader(config.Api.VersionReader);
                options.AssumeDefaultVersionWhenUnspecified = config.Api.AssumeDefaultVersionWhenUnspecified;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddAutoMapper();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new MyClaimRequirement("name", "Alice Smith")));
                options.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new MyClaimRequirement("name", "Bob Smith")));
                options.AddPolicy("CanRemoveCustomerData", policy => policy.Requirements.Add(new MyClaimRequirement("Customers", "Remove")));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
                {
                    o.Authority = config.IdentityServer.Authority;
                    o.Audience = config.IdentityServer.Audience;
                    o.RequireHttpsMetadata = config.IdentityServer.RequireHttpsMetadata;
                });

            RegisterServices(services);

            services.AddMvc(options =>
           {
               options.Filters.Add(typeof(ValidateModelStateAttribute));
           });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
        }
        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}