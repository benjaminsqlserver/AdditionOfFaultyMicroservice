namespace FacultyManagement.Domain.Schedules.Features;

using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Schedules.Dtos;
using FacultyManagement.Domain.Schedules.Services;
using FacultyManagement.Services;
using FacultyManagement.Domain.Schedules.Models;
using FacultyManagement.Exceptions;
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