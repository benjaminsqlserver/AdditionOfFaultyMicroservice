namespace FacultyManagement.Domain.Schedules.Features;

using FacultyManagement.Domain.Schedules.Services;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using MediatR;

public static class DeleteSchedule
{
    public sealed record Command(Guid ScheduleId) : IRequest;

    public sealed class Handler(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await scheduleRepository.GetById(request.ScheduleId, cancellationToken: cancellationToken);
            scheduleRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}