namespace FacultyManagement.Domain.Schedules.Features;

using FacultyManagement.Domain.Schedules.Dtos;
using FacultyManagement.Domain.Schedules.Services;
using FacultyManagement.Exceptions;
using FacultyManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetScheduleList
{
    public sealed record Query(ScheduleParametersDto QueryParameters) : IRequest<PagedList<ScheduleDto>>;

    public sealed class Handler(IScheduleRepository scheduleRepository)
        : IRequestHandler<Query, PagedList<ScheduleDto>>
    {
        public async Task<PagedList<ScheduleDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = scheduleRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToScheduleDtoQueryable();

            return await PagedList<ScheduleDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}