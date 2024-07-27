namespace CourseManagement.Domain.Enrollments.Features;

using CourseManagement.Domain.Enrollments.Dtos;
using CourseManagement.Domain.Enrollments.Services;
using CourseManagement.Exceptions;
using CourseManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetEnrollmentList
{
    public sealed record Query(EnrollmentParametersDto QueryParameters) : IRequest<PagedList<EnrollmentDto>>;

    public sealed class Handler(IEnrollmentRepository enrollmentRepository)
        : IRequestHandler<Query, PagedList<EnrollmentDto>>
    {
        public async Task<PagedList<EnrollmentDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = enrollmentRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToEnrollmentDtoQueryable();

            return await PagedList<EnrollmentDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}