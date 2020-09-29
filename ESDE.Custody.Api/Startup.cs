using AutoMapper;
using EDSE.Infra.IoC;
using ESDE.Custody.Repository.Context;
using ESDE.Infra.Bus;
using ESDE.Infra.Bus.MessageHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client.Core.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using System;

namespace ESDE.Custody.Api
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
            services.AddDbContext<CustodyDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name));
            }, ServiceLifetime.Singleton);

            var rabbitMqSection = Configuration.GetSection("RabbitMq");
            var exchangeSection = Configuration.GetSection("RabbitMqExchange");

            RegisterServices(services);

            services.AddRabbitMqClient(rabbitMqSection)
                .AddConsumptionExchange("financial-exchange", exchangeSection)
                .AddMessageHandlerTransient<CustodyMessageHandler>("custody-event-queue");

            services.AddAutoMapper(typeof(Program).Assembly);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Custody Microservice", Version = "v1" });
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.CustodyRegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Custody Microservice V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
