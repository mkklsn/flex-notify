// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using flex_notify.Domain.Models;
using Newtonsoft.Json;

namespace flex_notify.EventGridEventConsumerFunction
{
    public static class LeaveRequestCreatedEventHandlerFunction
    {
        [FunctionName("LeaveRequestCreatedEventHandlerFunction")]
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log)
        {
            var payload = eventGridEvent.Data as Payload;
            log.LogInformation($"EventGrid event >> subject {eventGridEvent.Subject} data {JsonConvert.SerializeObject(payload)} time {eventGridEvent.EventTime}");
        }
    }
}
