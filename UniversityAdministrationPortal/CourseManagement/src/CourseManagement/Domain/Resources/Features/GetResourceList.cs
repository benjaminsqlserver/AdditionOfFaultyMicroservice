namespace CourseManagement.Domain.Resources.Features;

using CourseManagement.Domain.Resources.Dtos;
using CourseManagement.Domain.Resources.Services;
using CourseManagement.Exceptions;
using CourseManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetResourceList
{
    public sealed record Query(ResourceParametersDto QueryParameters) : IRequest<PagedList<ResourceDto>>;

    public sealed class Handler(IResourceRepository resourceRepository)
        : IRequestHandler<Query, PagedList<ResourceDto>>
    {
        public async Task<PagedList<ResourceDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = resourceRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToResourceDtoQueryable();

            return await PagedList<ResourceDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}