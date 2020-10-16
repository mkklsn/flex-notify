using flex_notify.Application.Common.Interfaces;
using flex_notify.Infrastructure.ServiceBus;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace flex_notify.Infrastructure.Factory
{
    public class AzureServiceBusClientFactory : IAzureServiceBusClientFactory
    {
        private readonly IConfiguration _configuration;

        public AzureServiceBusClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IAzureServiceBusClient BuildQueueClient(string queueName)
        {
            var queueClient = new QueueClient(_configuration.GetConnectionString("ServiceBus"), queueName);
            return new AzureServiceBusClient(queueClient);
        }

        public async Task<IAzureServiceBusClient> BuildTopicClientAsync()
        {
            throw new NotImplementedException();
        }
    }
}
