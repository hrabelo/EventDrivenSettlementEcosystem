using ESDE.AssetCheck.Domain.Interfaces;
using System.Threading.Tasks;
using RabbitMQ.Client.Core.DependencyInjection.Services;

namespace ESDE.Infra.Bus
{
    public class RabbitMQBus : IEventBus
    {
        private readonly IQueueService _queueService;
        public RabbitMQBus(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public async Task Publish<T>(T content) where T : class
        {
            await _queueService.SendAsync(
                @object: content, "financial-exchange", "custody-event-queue");
        }
    }
}
