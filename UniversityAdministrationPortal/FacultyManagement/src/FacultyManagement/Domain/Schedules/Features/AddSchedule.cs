namespace FacultyManagement.Domain.Schedules.Features;

using FacultyManagement.Domain.Schedules.Services;
using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Schedules.Dtos;
using FacultyManagement.Domain.Schedules.Models;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddSchedule
{
    public sealed record Command(ScheduleForCreationDto ScheduleToAdd) : IRequest<ScheduleDto>;

    public sealed class Handler(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, ScheduleDto>
    {
        public async Task<ScheduleDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var scheduleToAdd = request.ScheduleToAdd.ToScheduleForCreation();
            var schedule = Schedule.Create(scheduleToAdd);

            await scheduleRepository.Add(schedule, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return schedule.ToScheduleDto();
        }
    }
}