using flex_notify.Application.Common.Interfaces;
using flex_notify.Domain.Models;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

namespace flex_notify.Infrastructure.ServiceBus
{
    public class AzureServiceBusClient : IAzureServiceBusClient
    {
        private readonly IQueueClient _queueClient;
        private readonly ITopicClient _topicClient;

        public AzureServiceBusClient(QueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public AzureServiceBusClient(TopicClient topicClient)
        {
            _topicClient = topicClient;
        }

        public async Task Enqueue<T>(T queueItem) where T: IMessage
        {
            await _queueClient.SendAsync(new Message());

            throw new System.NotImplementedException();
        }

        public async Task Publish<T>(T message) where T : IMessage
        {
            await _topicClient.SendAsync(new Message());
            
            throw new System.NotImplementedException();
        }
    }
}
