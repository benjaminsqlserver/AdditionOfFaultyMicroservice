namespace FacultyManagement.Domain.Schedules.Features;

using FacultyManagement.Domain.Schedules.Dtos;
using FacultyManagement.Domain.Schedules.Services;
using FacultyManagement.Exceptions;
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