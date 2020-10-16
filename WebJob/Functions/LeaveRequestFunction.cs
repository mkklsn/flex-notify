using Microsoft.Azure.Documents;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebJob.Functions
{
    public class LeaveRequestFunction
    {
        [FunctionName("LeaveRequestCreatedCapture")]
        public async Task Run([CosmosDBTrigger(
            databaseName: "Flex",
            collectionName: "LeaveRequests",
            ConnectionStringSetting = "CosmosDBConnection",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> documents,
            [EventGrid(TopicEndpointUri = "MyEventGridTopicUriSetting", TopicKeySetting = "MyEventGridTopicKeySetting")]IAsyncCollector<EventGridEvent> outputEvents,
            ILogger log)
        {
            // Iterate through all created LeaveRequest entities in DB. See CreateLeaveRequestCommand.cs
            foreach (var document in documents)
            {
                // Foreach created LeaveRequest entity, create an Event Grid even
                var leaveRequestCreatedEvent = new EventGridEvent("message-id-" + document.Id, "subject-name", "event-data", "event-type", DateTime.UtcNow, "1.0");
                await outputEvents.AddAsync(leaveRequestCreatedEvent);
            }
        }

        [FunctionName("EventGridEventCapture")]
        public async Task EventGridTest(
            [EventGridTrigger] EventGridEvent eventGridEvent,
            [SignalR(HubName = "HubName")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());

            var eventPayload = eventGridEvent.Data;

            // 1. Parse eventPayload variable
            // 2. Do actions based on eventPayload 
            //    e.g. publish to signalr, use SendGrid email service, Twilio SMS, publish to 3rd part APIs, etc

            await PublishToSignalR(signalRMessages, eventPayload);
        }

        private async Task PublishToSignalR(IAsyncCollector<SignalRMessage> signalRMessages, object payload)
        {
            await signalRMessages.AddAsync(
                new SignalRMessage
                {
                    GroupName = "GroupName",
                    Target = "EventName",
                    Arguments = new[] {
                        payload // Payload to SignalR
                    }
                }
            );
        }
    }
}
