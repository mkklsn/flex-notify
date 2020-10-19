using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using flex_notify.Domain.Models;

namespace flex_notify.WebJob
{
    public static class LeaveRequestNotificationFunction
    {
        [FunctionName("LeaveRequestNotificationFunction")]
        public static void Run(
            [CosmosDBTrigger(
                databaseName: "FlexNotifyCosmosDb",
                collectionName: "LeaveRequests",
                ConnectionStringSetting = "CosmosDBConnectionString",
                LeaseCollectionName = "leases",
                CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> input,
            [EventGrid(
                TopicEndpointUri = "FlexNotifyLeaveRequestCreatedTopicUri",
                TopicKeySetting = "FlexNotifyLeaveRequestCreatedTopicKey")]IAsyncCollector<EventGridEvent> outputEvents,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);

                var eventType = "leave-request-created";
                for (int i = 0; i < input.Count; i++) {
                    var createdEvent = new EventGridEvent()
                    {
                        Id = Guid.NewGuid().ToString(),
                        EventType = eventType,
                        Data = new Payload
                        {
                            LeaveRequestId = input[i].Id,
                            Email = input[i].GetPropertyValue<string>("email")
                        },
                        EventTime = DateTime.UtcNow,
                        Subject = eventType,
                        DataVersion = "1.0"
                    };

                    log.LogInformation("event id " + createdEvent.Id);

                    outputEvents.AddAsync(createdEvent).GetAwaiter().GetResult();
                }

                log.LogInformation($"Finished emitting {input.Count} events to EventGrid.");
            }
        }
    }
}
