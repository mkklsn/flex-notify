using System.Threading.Tasks;

namespace flex_notify.Application.Common.Interfaces
{
    public interface IAzureServiceBusClientFactory
    {
        IAzureServiceBusClient BuildQueueClient(string queueName);
        Task<IAzureServiceBusClient> BuildTopicClientAsync();
    }
}
