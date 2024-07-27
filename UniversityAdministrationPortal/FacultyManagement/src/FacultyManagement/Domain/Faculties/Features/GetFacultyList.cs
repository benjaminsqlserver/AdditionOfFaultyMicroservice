namespace FacultyManagement.Domain.Faculties.Features;

using FacultyManagement.Domain.Faculties.Dtos;
using FacultyManagement.Domain.Faculties.Services;
using FacultyManagement.Exceptions;
using FacultyManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetFacultyList
{
    public sealed record Query(FacultyParametersDto QueryParameters) : IRequest<PagedList<FacultyDto>>;

    public sealed class Handler(IFacultyRepository facultyRepository)
        : IRequestHandler<Query, PagedList<FacultyDto>>
    {
        public async Task<PagedList<FacultyDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = facultyRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToFacultyDtoQueryable();

            return await PagedList<FacultyDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}