namespace CourseManagement.Domain.Schedules.Features;

using CourseManagement.Domain.Schedules.Services;
using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.Dtos;
using CourseManagement.Domain.Schedules.Models;
using CourseManagement.Services;
using CourseManagement.Exceptions;
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