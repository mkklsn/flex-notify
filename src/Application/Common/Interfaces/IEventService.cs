using flex_notify.Domain.Enums;
using System.Threading.Tasks;

namespace flex_notify.Application.Common.Interfaces
{
    public interface IEventService
    {
        Task Publish<T>(T eventPayload, EventType eventType);
    }
}
