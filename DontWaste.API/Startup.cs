using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dontwaste.Api.Data;
using Dontwaste.Api.Data.Repositories;
using DontWaste.Api.Business;
using DontWaste.Api.Business.Contracts;
using DontWaste.Api.Core.Contracts;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using NSwag.AspNetCore;
using DontWaste.API.MiddleWare;
using NJsonSchema;

namespace DontWaste.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DontWasteContext>(option => option.UseSqlite("Data Source=DontWaste.db"), ServiceLifetime.Scoped);
            services.AddTransient<IDataRepositoryFactory, DataRepositoryFactory>();
            services.AddTransient<IUserRepository, UserRepository>();
            //services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));
            services.AddTransient<IDataRepositoryFactory, DataRepositoryFactory>();
            services.AddTransient<IDataRepositoryFactory, DataRepositoryFactory>();
            services.AddTransient<IDataRepositoryFactory, DataRepositoryFactory>();
            services.AddTransient<IBusinessEngine, BusinessEngine>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                         .AddEntityFrameworkStores<DontWasteContext>()
                         .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/myapp-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseHangfireServer();
            //app.UseHangfireDashboard();
            app.ConfigureExceptionHandler(loggerFactory);

            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
            });
            app.UseMvc();
        }
    }
}
