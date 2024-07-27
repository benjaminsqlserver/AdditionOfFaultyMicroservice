namespace CourseManagement.Domain.Prerequisites.Features;

using CourseManagement.Domain.Prerequisites.Dtos;
using CourseManagement.Domain.Prerequisites.Services;
using CourseManagement.Exceptions;
using CourseManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetPrerequisiteList
{
    public sealed record Query(PrerequisiteParametersDto QueryParameters) : IRequest<PagedList<PrerequisiteDto>>;

    public sealed class Handler(IPrerequisiteRepository prerequisiteRepository)
        : IRequestHandler<Query, PagedList<PrerequisiteDto>>
    {
        public async Task<PagedList<PrerequisiteDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = prerequisiteRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToPrerequisiteDtoQueryable();

            return await PagedList<PrerequisiteDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}