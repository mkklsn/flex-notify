using flex_notify.Application.Common.Interfaces;
using System;

namespace flex_notify.Infrastructure.Event.Models
{
    public class LeaveRequestEvent : IEvent
    {
        public Guid LeaveRequestId { get; set; }
    }
}
