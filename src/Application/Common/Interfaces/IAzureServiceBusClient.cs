using flex_notify.Domain.Models;
using System.Threading.Tasks;

namespace flex_notify.Application.Common.Interfaces
{
    public interface IAzureServiceBusClient
    {
        Task Enqueue<T>(T queueItem) where T : IMessage;
        Task Publish<T>(T message) where T : IMessage;
    }
}
