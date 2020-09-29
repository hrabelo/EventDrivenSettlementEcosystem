using ESDE.Custody.Domain.Interfaces;
using RabbitMQ.Client.Core.DependencyInjection.MessageHandlers;
using System;

namespace ESDE.Infra.Bus.MessageHandler
{
    public class CustodyMessageHandler : IMessageHandler
    {
        private readonly ICustodyApplication _custodyApp;

        public CustodyMessageHandler(ICustodyApplication custodyApp)
        {
            _custodyApp = custodyApp;
        }
        public void Handle(string message, string routingKey)
        {
            _custodyApp.Process(message);
        }
    }
}
