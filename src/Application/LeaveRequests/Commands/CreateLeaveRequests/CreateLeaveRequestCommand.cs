using flex_notify.Application.Common.Interfaces;
using flex_notify.Domain.Entities;
using flex_notify.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace flex_notify.Application.LeaveRequests.Commands.CreateLeaveRequests
{
    public class CreateLeaveRequestCommand : IRequest<Guid>
    {
        public CreateLeaveRequestCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }

    public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequestCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEventService _eventService;

        public CreateLeaveRequestHandler(IApplicationDbContext context, IEventService eventService)
        {
            _context = context;
            _eventService = eventService;
        }

        public async Task<Guid> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = new LeaveRequest();

            entity.UserId = request.UserId;

            _context.LeaveRequests.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            /*
             * I would prefer to avoid "manually" emit an event here.
             * But to do that, we would need use CosmosDB instead
             * CosmosDB has a "CosmosDbTrigger" binding that can be attached to Azure Function
             * see LeaveRequestFunction.cs
            */
            await _eventService.Publish(new object(), EventType.LeaveRequest);

            return entity.Id;
        }
    }
}
