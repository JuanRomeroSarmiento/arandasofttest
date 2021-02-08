using AutoMapper;
using ArandSoft.Identity.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using ArandaSoft.Identity.ResourceAccessor.Interfaces;
using ArandaSoft.Identity.ResourceAccessor.Repositories;
using ArandaSoftware.Identity.Manager.Interfaces;
using ArandaSoftware.Identity.Manager.Services;
using ArandaSoftware.Identity.Manager;
using ArandaSoft.Identity.API.Middlewares;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ArandaSoft.Identity.API.Infrastructure;

namespace ArandaSoft.Identity
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArandaSoft.Identity", Version = "v1" });
            });
            services.AddDbContext<IdentityDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityDataBase"));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILocalIdentityService, LocalIdentityService>();
            services.AddScoped<IIdentityManager, Manager>();

            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
               {

                   //Here we have specified which parameters must be taken into account to consider JWT as valid
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true, // Validate de server that generates the token
                       ValidateAudience = true, // Validate the recipient of the token is authorized to receive
                       ValidateLifetime = true, // Check if the token is not expired and the signing key of the issuer is valid
                       ValidateIssuerSigningKey = true, // Validate signature of the token
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       ValidAudience = Configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                   };
               });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.SelectPolicy,
                    policy => policy.RequireClaim(Constants.SelectPolicyKey, Constants.SelectPolicyName));
                options.AddPolicy(Constants.CreatePolicy,
                    policy => policy.RequireClaim(Constants.CreatePolicyKey, Constants.CreatePolicyName));
                options.AddPolicy(Constants.UpdatePolicy,
                    policy => policy.RequireClaim(Constants.UpdatePolicyKey, Constants.UpdatePolicyName));
                options.AddPolicy(Constants.DeletePolicy,
                    policy => policy.RequireClaim(Constants.DeletePolicyKey, Constants.DeletePolicyName));
            });

            services.AddSwaggerGen(options =>
            {                
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArandaSoft.Identity v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
