using ArandaSoft.Identity.API.Infrastructure;
using ArandaSoft.Identity.API.Middlewares;
using ArandaSoft.Identity.ResourceAccessor.Interfaces;
using ArandaSoft.Identity.ResourceAccessor.Repositories;
using ArandaSoftware.Identity.Manager;
using ArandaSoftware.Identity.Manager.Interfaces;
using ArandaSoftware.Identity.Manager.Services;
using ArandSoft.Identity.DataBase;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace ArandaSolft.Identity.IntegrationTests.API
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
            services.AddControllers().AddApplicationPart(Assembly.Load("ArandaSoft.Identity.API")).AddControllersAsServices();
            
            services.AddDbContext<IdentityDBContext>(options =>
            {
                options.UseInMemoryDatabase("IdentityDBTest-" + Guid.NewGuid());
            }, ServiceLifetime.Singleton);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILocalIdentityService, LocalIdentityService>();
            services.AddScoped<IIdentityManager, Manager>();

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
                    policy => policy.RequireClaim(Constants.UpdatePolicy, Constants.UpdatePolicyName));
                options.AddPolicy(Constants.DeletePolicy,
                    policy => policy.RequireClaim(Constants.DeletePolicyKey, Constants.DeletePolicyName));
            });

            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));            
            
        }
        public void Configure(IApplicationBuilder app)
        {
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
