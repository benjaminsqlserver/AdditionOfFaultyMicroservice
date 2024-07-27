namespace FacultyManagement.Domain.CourseAssignments.Features;

using FacultyManagement.Domain.CourseAssignments.Dtos;
using FacultyManagement.Domain.CourseAssignments.Services;
using FacultyManagement.Exceptions;
using FacultyManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetCourseAssignmentList
{
    public sealed record Query(CourseAssignmentParametersDto QueryParameters) : IRequest<PagedList<CourseAssignmentDto>>;

    public sealed class Handler(ICourseAssignmentRepository courseAssignmentRepository)
        : IRequestHandler<Query, PagedList<CourseAssignmentDto>>
    {
        public async Task<PagedList<CourseAssignmentDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = courseAssignmentRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToCourseAssignmentDtoQueryable();

            return await PagedList<CourseAssignmentDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}