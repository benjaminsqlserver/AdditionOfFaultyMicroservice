namespace CourseManagement.Domain.Instructors.Features;

using CourseManagement.Domain.Instructors.Dtos;
using CourseManagement.Domain.Instructors.Services;
using CourseManagement.Exceptions;
using CourseManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetInstructorList
{
    public sealed record Query(InstructorParametersDto QueryParameters) : IRequest<PagedList<InstructorDto>>;

    public sealed class Handler(IInstructorRepository instructorRepository)
        : IRequestHandler<Query, PagedList<InstructorDto>>
    {
        public async Task<PagedList<InstructorDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = instructorRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToInstructorDtoQueryable();

            return await PagedList<InstructorDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}