using DA.Domain.DTO;
using DA.Infrastructure.SQL.Data;
using DempApp.Helper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;

namespace DempApp
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
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     var audienceConfig = Configuration.GetSection("Audience");
                     var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));

                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = signingKey,
                         ValidateIssuer = true,
                         ValidIssuer = audienceConfig["Iss"],
                         ValidateAudience = true,
                         ValidAudience = audienceConfig["Aud"],
                         ValidateLifetime = true,
                         ClockSkew = TimeSpan.Zero,
                         RequireExpirationTime = true

                     };
                 });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowAllOrigin", options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });

          //  services.AddControllers();
            services.AddControllers(options =>
            {
                options.ModelBinderProviders.Insert(0, new ModelBinderProvider());
            }).SetCompatibilityVersion(CompatibilityVersion.Latest).AddFluentValidation();

            //services.AddMvc(options =>
            //{
            //    options.ModelBinderProviders.Insert(0, new ModelBinderProvider());
            //}).SetCompatibilityVersion(CompatibilityVersion.Latest).AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DempApp",
                    Version = "v1",
                    Description = "Demo App .NET 5 Micro Service.",
                });
                #region commented Codes
                //var security = new Dictionary<string, IEnumerable<string>>
                //{
                //    {"Bearer", new string[] { }},
                //};

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = "header",
                //    Type = "apiKey"
                //});
                //c.AddSecurityRequirement(security);
                #endregion

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => new ErrorMessage() { error = e.ErrorMessage })).ToList();

                    var result = new ServiceResponse
                    {
                        success = false,
                        msg = "Validation Errors",
                        errorlst = errors
                    };

                    return new BadRequestObjectResult(result);
                };
            });

            //  services.Configure<IISOptions>(options => options.ForwardWindowsAuthentication = true);
            var connectionString = Configuration.GetConnectionString("DotNetCoreConnection");
            services.AddDbContext<DADBContext>(d => d.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddDbContext<DADBContext>(options =>
            options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(90)));
            // services.AddAutoMapper(typeof(Mapping));
            services.AddLogging();
            /// configure dependancies. 
            /// 
            var dependancy = new DependancyConfig.DependancyConfig(services, Configuration);
            dependancy.ConfigureServices();


            #region Commented Codes
            //services.AddTransient((serviceProvider) =>
            //{
            //    var config = serviceProvider.GetRequiredService<IConfiguration>();
            //    return new SmtpClient()
            //    {
            //        Host = config.GetValue<String>("Email:Smtp:Host"),
            //        Port = config.GetValue<int>("Email:Smtp:Port"),
            //        Credentials = new NetworkCredential(
            //                config.GetValue<String>("Email:Smtp:Username"),
            //                config.GetValue<String>("Email:Smtp:Password")
            //            )
            //    };
            //});
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DempApp v1"));
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
