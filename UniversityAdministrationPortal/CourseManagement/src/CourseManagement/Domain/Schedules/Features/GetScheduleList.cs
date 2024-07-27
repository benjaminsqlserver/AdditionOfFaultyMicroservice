namespace CourseManagement.Domain.Schedules.Features;

using CourseManagement.Domain.Schedules.Dtos;
using CourseManagement.Domain.Schedules.Services;
using CourseManagement.Exceptions;
using CourseManagement.Resources;
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