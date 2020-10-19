using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;

namespace flex_notify.CreateLeaveHttpFunction
{
    public static class CreateLeaveHttpFunction
    {
        [FunctionName("CreateLeaveHttpFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "FlexNotifyCosmosDb",
                collectionName: "LeaveRequests",
                ConnectionStringSetting = "CosmosDBConnectionString")]out dynamic document,
            ILogger log)
        {
            log.LogInformation("Create LeaveRequest function triggered.");

            document = new { id = Guid.NewGuid(), email = $"sample@email.com" };

            return new OkResult();
        }
    }
}
