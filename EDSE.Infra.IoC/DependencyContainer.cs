using ESDE.AssetCheck.Application;
using ESDE.AssetCheck.Domain.Interfaces;
using ESDE.AssetCheck.Repository.Context;
using ESDE.AssetCheck.Repository.Repositories;
using ESDE.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace EDSE.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();

            services.AddTransient<IAssetCheckApplication, AssetCheckApplication>();
            services.AddTransient<IAssetRepository, AssetRepository>();
            services.AddTransient<AssetDbContext>();

        }
    }
}
