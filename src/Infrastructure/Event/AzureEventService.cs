using flex_notify.Application.Common.Interfaces;
using flex_notify.Domain.Common;
using flex_notify.Domain.Enums;
using flex_notify.Domain.Models;
using System;
using System.Threading.Tasks;

namespace flex_notify.Infrastructure.Event
{
    public class AzureEventService : IEventService
    {
        private readonly IAzureServiceBusClientFactory _azSbFactory;

        public AzureEventService(IAzureServiceBusClientFactory azSbFactory)
        {
            _azSbFactory = azSbFactory;
        }
        
        public async Task Publish<T>(T eventPayload, EventType eventType)
        {
            IAzureServiceBusClient azSbClient;

            switch (eventType)
            {
                case EventType.LeaveRequest:
                    azSbClient = _azSbFactory.BuildQueueClient(Constants.LeaveRequestQueueName);
                    await azSbClient.Enqueue(new LeaveRequestMessage());
                    break;
            }

            throw new NotImplementedException();
        }
    }
}
