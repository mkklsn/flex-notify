using flex_notify.Application.LeaveRequests.Commands.CreateLeaveRequests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace flex_notify.WebUI.Controllers
{
    public class LeaveRequestController : ApiController
    {
        [HttpPost]
        public async Task<Guid> CreateAsync([FromBody] Guid userId)
        {
            return await Mediator.Send(new CreateLeaveRequestCommand(userId));
        }
    }
}
