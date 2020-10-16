using flex_notify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace flex_notify.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<LeaveRequest> LeaveRequests { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
