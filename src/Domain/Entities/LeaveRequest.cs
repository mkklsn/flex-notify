using flex_notify.Domain.Common;
using System;

namespace flex_notify.Domain.Entities
{
    public class LeaveRequest : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        // TODO: implement other properties
    }
}
