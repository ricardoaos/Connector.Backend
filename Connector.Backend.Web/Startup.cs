﻿using System;
using System.IO;
using Connector.Backend.Application;
using Connector.Backend.Domain;
using Connector.Backend.Domain.Entities;
using Connector.Backend.DTO;
using Connector.Backend.Infra;
using Connector.Backend.Infra.SqlServer;
using Connector.Backend.Web.HostedServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tnf.Configuration;

namespace BasicCrud.Web
{
    public class Startup
    {
        DatabaseConfiguration DatabaseConfiguration { get; }

        public Startup(IConfiguration configuration)
        {
            DatabaseConfiguration = new DatabaseConfiguration(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCorsAll("AllowAll")
                .AddApplicationServiceDependency();  // dependencia da camada BasicCrud.Application

            services.AddTnfAspNetCore(builder =>
            {
                builder.UseDomainLocalization();

                builder.Repository(repositoryConfig =>
                {
                    repositoryConfig.Entity<IEntity>(entity =>
                        entity.RequestDto<IDefaultRequestDto>((e, d) => e.Id == d.Id));
                });

                builder.DefaultConnectionString(DatabaseConfiguration.ConnectionString);
            });

            services.AddSingleton(DatabaseConfiguration);

            if (DatabaseConfiguration.DatabaseType == DatabaseType.SqlServer)
                services.AddSqlServerDependency();
            else
                throw new NotSupportedException("No database configuration found");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basic Crud API", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BasicCrud.Web.xml"));
            });

            services.AddResponseCompression();

            services.AddHostedService<MigrationHostedService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            app.UseTnfAspNetCore();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseResponseCompression();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basic Crud API v1");
            });

            app.UseEndpoints(builder =>
            {
                builder.MapDefaultControllerRoute();
            });
        }
    }
}
