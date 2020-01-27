using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using TodoListApp.Configuration.Core.Constructure;
using TodoListApp.Data.Common;
using TodoListApp.Data.Common.Infrastructure;
using TodoListApp.Data.Common.Repositories;
using TodoListApp.Model.Common.EntityFramework.Common;
using TodoListApp.Model.Common.EntityFramework.UserManagement;
using TodoListApp.Service.Common.Interfaces;
using TodoListApp.Service.Common.Services;

namespace AngularNetCoreIMS.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Entity Config
            services.AddDbContext<TodoAppNetCoreDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("TodoListApp.Data.Common")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<TodoAppNetCoreDBContext>()
                .AddDefaultTokenProviders();

            services.AddCors(option =>
            {
                option.AddPolicy(MyAllowSpecificOrigins,
                    builder => {
                        builder.WithOrigins("*");
                    });
            });

            services.AddTransient<TaskInitialDB>();
            services.AddTransient<IUnitOfWork, CommonUnitOfWork>();

            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IStateStatusRepository, StateStatusRepository>();
            services.AddTransient<ITaskService, TaskService>();

            services.AddMvc();

            //Swagger
            services.AddAutoMapper();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BE - .NET Core 2.1 API", Description = "Todo Task API" });
                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"CorewithSwagger.xml";
                c.IncludeXmlComments(xmlPath);
            });

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TaskInitialDB taskInitialDB)
        {
            #region static files

            app.UseStaticFiles();

            #endregion static files

            #region Handle Exception

            #endregion Handle Exception

            //app.UseCors("AngularNetCoreIMSClient");
            app.UseCors(builder => builder
                .WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseDeveloperExceptionPage();

            app.UseDatabaseErrorPage();

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net Core 2.1 - Todo Task v1");
            });

            #region route

            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "home", action = "index" });
            });

            #endregion route

            taskInitialDB.Seed();
        }
    }
}