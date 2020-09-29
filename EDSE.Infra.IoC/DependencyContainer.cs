using ESDE.AssetCheck.Application;
using ESDE.AssetCheck.Domain.Interfaces;
using ESDE.AssetCheck.Repository.Context;
using ESDE.AssetCheck.Repository.Repositories;
using ESDE.Custody.Application;
using ESDE.Custody.Domain.Interfaces;
using ESDE.Custody.Repository.Context;
using ESDE.Custody.Repository.Repositories;
using ESDE.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace EDSE.Infra.IoC
{
    public class DependencyContainer
    {
        public static void AssetCheckRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();

            services.AddTransient<IAssetCheckApplication, AssetCheckApplication>();
            services.AddTransient<IAssetRepository, AssetRepository>();
            services.AddTransient<AssetDbContext>();

        }

        public static void CustodyRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();

            services.AddTransient<ICustodyApplication, CustodyApplication>();
            services.AddTransient<ICustodyRepository, CustodyRepository>();
            services.AddSingleton<CustodyDbContext>();

        }
    }
}
