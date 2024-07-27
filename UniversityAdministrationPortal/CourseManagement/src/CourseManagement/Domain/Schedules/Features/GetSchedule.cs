namespace CourseManagement.Domain.Schedules.Features;

using CourseManagement.Domain.Schedules.Dtos;
using CourseManagement.Domain.Schedules.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetSchedule
{
    public sealed record Query(Guid ScheduleId) : IRequest<ScheduleDto>;

    public sealed class Handler(IScheduleRepository scheduleRepository)
        : IRequestHandler<Query, ScheduleDto>
    {
        public async Task<ScheduleDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await scheduleRepository.GetById(request.ScheduleId, cancellationToken: cancellationToken);
            return result.ToScheduleDto();
        }
    }
}