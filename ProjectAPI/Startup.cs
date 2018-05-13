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

            services.AddDbContext<ProjectDbContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ProjectAPI")));

           services.AddApiVersioning(options =>
           {
               options.ApiVersionReader = new HeaderApiVersionReader("api-version");
               options.AssumeDefaultVersionWhenUnspecified = true;
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

            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddJwtBearer(options =>
            // {
            //     options.Authority = "http://localhost:2000";
            //     options.RequireHttpsMetadata = false;
            //     options.Audience = "postman-api";
            //     options.AllowedScopes = { "postman_api" },

            // });

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
                    o.Authority = "http://localhost:2000";
                    o.Audience = "postman_api";
                    o.RequireHttpsMetadata = false;
                });

            RegisterServices(services);

            services.AddMvc();
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

