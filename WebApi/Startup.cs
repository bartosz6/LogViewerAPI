using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using Infrastructure.Interfaces;
using Domain.VarnishLog;
using Infrastructure.Repositories;
using Infrastructure.Utils.VarnishLogParser;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        private IContainer _container;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                })
            );

            services.AddMvc(options =>
            {
                options.Filters.Add(
                    new AuthorizeFilter(
                        (new AuthorizationPolicyBuilder())
                        .RequireAuthenticatedUser()
                        .Build()
                    )
                );
               // options.OutputFormatters.RemoveType<TextOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            })
            .AddControllersAsServices()
            .AddJsonOptions(options =>
                  {
                      options.SerializerSettings.ContractResolver =
                          new CamelCasePropertyNamesContractResolver();
                  });



            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            RegisterDI(containerBuilder);

            _container = containerBuilder.Build();
            return new AutofacServiceProvider(_container);
        }

        private void RegisterDI(ContainerBuilder containerBuilder)
        {
            var infrastructureAssemblyName = new AssemblyName("Infrastructure");
            var applicationAssemblyName = new AssemblyName("Application");
            var domainAssemblyName = new AssemblyName("Domain");
            var webAssemblyName = new AssemblyName("WebApi");

            containerBuilder
                .RegisterAssemblyTypes(Assembly.Load(infrastructureAssemblyName))
                .Where(@type =>
                    @type.Name.EndsWith("Dispatcher")
                )
                .AsImplementedInterfaces();

            containerBuilder
                .RegisterAssemblyTypes(Assembly.Load(applicationAssemblyName))
                .Where(@type =>
                    @type.Name.EndsWith("Handler")
                )
                .AsImplementedInterfaces();
            containerBuilder
                .RegisterAssemblyTypes(Assembly.Load(domainAssemblyName))
                .Where(@type =>
                    @type.Name.EndsWith("Command")
                    || @type.Name.EndsWith("Query")
                )
                .AsImplementedInterfaces();

            containerBuilder
                .RegisterAssemblyTypes(Assembly.Load(webAssemblyName))
                .Where(@type =>
                    @type.Name.EndsWith("Controller")
                )
                .InstancePerLifetimeScope()
                .PropertiesAutowired();

            containerBuilder
                .RegisterType<FileRepository>()
                .As<IRepository<VarnishLog>>()
                .SingleInstance();

            containerBuilder
                .RegisterType<VarnishLogParser>()
                .As<IParser<VarnishLog>>()
                .SingleInstance();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("AllowAllOrigins");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();

            app.UseMvc(options =>
            {
            });

            //Kill all dependencies
            appLifetime.ApplicationStopped.Register(() => _container.Dispose());
        }
    }
}
