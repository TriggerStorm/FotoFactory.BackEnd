using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.AppService.Validators;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;
using InfraStructure.SQLLite.Data;
using InfraStructure.SQLLite.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace FotoFactory.BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<FotoFactoryContext>(
                    opt =>
                    {
                        opt.UseSqlite("Data Source= FotoFactoryApp.db");    
            });
            }
            else
            {
                services.AddDbContext<FotoFactoryContext>
                    (opt =>
                    {
                        opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
                    });
            }

            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
           
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserValidator, UserValidator>();

            services.AddScoped<IPosterRepository, PosterRepository>();
            services.AddScoped<IPosterService, PosterService>();
            services.AddScoped<IPosterValidator, PosterValidator>();

            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<ICollectionValidator, CollectionValidator>();

            services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IFavouriteValidator, FavouriteValidator>();

            services.AddTransient<IDBInitialiser, DBInitialiser>();

            services.AddSingleton<IAuthenticationHelper>(new
               AuthenticationHelper(secretBytes));

            #region CORS
            // Configure the default CORS policy.
            services.AddCors(options =>
                options.AddDefaultPolicy(
                  builder =>
                  {
                      builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                  })
             );
            #endregion
            #region Swagger
            //Register the Swagger generator using Swashbuckle.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FotoFactory API",
                    Description = "A simple example ASP.NET Core Web API"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers().AddNewtonsoftJson(options =>
            {    // Use the default property (Pascal) casing
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                   options.SerializerSettings.MaxDepth = 5;  // 100 pet limit per owner
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using var scope = app.ApplicationServices.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<FotoFactoryContext>();
                var dbIntialiser = scope.ServiceProvider.GetRequiredService<IDBInitialiser>();

                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                dbIntialiser.SeedDB(ctx);
            }
            else if (env.IsProduction())
            {
                using var scope = app.ApplicationServices.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<FotoFactoryContext>();
                var dbIntialiser = scope.ServiceProvider.GetRequiredService<IDBInitialiser>();

                ctx.Database.EnsureCreated();

                ctx.Database.ExecuteSqlRaw("DROP TABLE Users");
                ctx.Database.ExecuteSqlRaw("DROP TABLE Posters");
                ctx.Database.ExecuteSqlRaw("DROP TABLE Sizes");
                ctx.Database.ExecuteSqlRaw("DROP TABLE Frames");
                ctx.Database.ExecuteSqlRaw("DROP TABLE WorkSpaces");
                ctx.Database.ExecuteSqlRaw("DROP TABLE WorkSpacePosters");
                ctx.Database.ExecuteSqlRaw("DROP TABLE Tags");

                ctx.Database.EnsureCreated();

                dbIntialiser.SeedDB(ctx);
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
