namespace CourseManagement.Domain.Courses.Features;

using CourseManagement.Domain.Courses.Dtos;
using CourseManagement.Domain.Courses.Services;
using CourseManagement.Exceptions;
using CourseManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetCourseList
{
    public sealed record Query(CourseParametersDto QueryParameters) : IRequest<PagedList<CourseDto>>;

    public sealed class Handler(ICourseRepository courseRepository)
        : IRequestHandler<Query, PagedList<CourseDto>>
    {
        public async Task<PagedList<CourseDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = courseRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToCourseDtoQueryable();

            return await PagedList<CourseDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}