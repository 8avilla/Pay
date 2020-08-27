using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Auto.Pay.Persistence.Interface;
using Auto.Pay.Servicio.Api.Helpers;
using System.Text;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Auto.Pay.Transversal.Common;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Auto.Pay.BusinessLogic.Core;
using Auto.Pay.Servicio.Api.Exceptions;
using Microsoft.Extensions.Logging;
using Auto.Pay.Persistence.Data;
using Auto.Pay.Persistence.Repository;
using Auto.Pay.Transversal.Logging;
using Auto.Pay.Application.Interfaces;
using Auto.Pay.Aplicacion.Main;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Auto.Pay.Servicio.Api
{
    public class Startup
    {

        readonly string myPolicy = "PoliticaPrincipal";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins("*")
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            IConfigurationSection appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();

            services.AddSingleton(Configuration);
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddScoped<IManagerBusinessLogic, ManagerBusinessLogic>();
            services.AddScoped<IOrderApplication, OrderApplication>();
            services.AddScoped<IUnitOfWorkPersistence, UnitOfWorkPersistence>();
            services.AddScoped(typeof(IGenericPersistenceRepository<>), typeof(GenericPersistenceRepository<>));

            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            string Issuer = appSettings.Issuer;
            string Audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.Events = new JwtBearerEvents
               {
                   OnTokenValidated = context =>
                   {
                       return Task.CompletedTask;
                   },
                   OnAuthenticationFailed = context =>
                   {
                       if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                       {
                           context.Response.Headers.Add("Token-Expired", "true");
                       }
                       return Task.CompletedTask;
                   }
               };

               x.RequireHttpsMetadata = false;
               x.SaveToken = false;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidIssuer = Issuer,
                   ValidateAudience = false,
                   ValidAudience = Audience,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero
               };
           });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pay",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization by API key.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new string[]{ }
                    }
                });
            });

            services.AddDbContext<ContextPay>(
                options => options
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            //services.AddDbContext<ContextPay>(options =>
                    //options.UseSqlServer("server=192.168.4.35\\QURII; initial catalog=ContratoDigital; user id= saa; password=D3v3l0_2020$;"));



        }

         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Log-{Date}.txt");
            ILogger logger = loggerFactory.CreateLogger<Program>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureExceptionHandler(logger);

            app.UseRouting();
                
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QURII V1");
            });

            app.UseCors(myPolicy);
            app.UseAuthentication();
            app.UseAuthentication();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
