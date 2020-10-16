using flex_notify.Application.Common.Interfaces;
using System;

namespace flex_notify.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
