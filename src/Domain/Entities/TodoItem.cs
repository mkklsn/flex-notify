using flex_notify.Domain.Common;
using flex_notify.Domain.Enums;
using System;

namespace flex_notify.Domain.Entities
{
    public class TodoItem : AuditableEntity
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }


        public TodoList List { get; set; }
    }
}
