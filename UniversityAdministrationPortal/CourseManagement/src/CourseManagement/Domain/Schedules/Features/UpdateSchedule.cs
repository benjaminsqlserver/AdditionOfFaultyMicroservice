namespace CourseManagement.Domain.Schedules.Features;

using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.Dtos;
using CourseManagement.Domain.Schedules.Services;
using CourseManagement.Services;
using CourseManagement.Domain.Schedules.Models;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateSchedule
{
    public sealed record Command(Guid ScheduleId, ScheduleForUpdateDto UpdatedScheduleData) : IRequest;

    public sealed class Handler(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var scheduleToUpdate = await scheduleRepository.GetById(request.ScheduleId, cancellationToken: cancellationToken);
            var scheduleToAdd = request.UpdatedScheduleData.ToScheduleForUpdate();
            scheduleToUpdate.Update(scheduleToAdd);

            scheduleRepository.Update(scheduleToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}