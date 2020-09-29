using ESDE.AssetCheck.Domain.Interfaces;
using System.Threading.Tasks;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using RabbitMQ.Client.Core.DependencyInjection.MessageHandlers;
using System;

namespace ESDE.Infra.Bus
{
    public class RabbitMQBus : IEventBus, IMessageHandler
    {
        private readonly IQueueService _queueService;
        public RabbitMQBus(IQueueService queueService)
        {
            _queueService = queueService;
            
        }

        public void Handle(string message, string routingKey)
        {
            Console.WriteLine(message);
        }

        public async Task Publish<T>(T content) where T : class
        {
            await _queueService.SendAsync(
                content, "financial-exchange", "custody-event-queue");
        }
    }
}
