namespace FacultyManagement.Domain.Qualifications.Features;

using FacultyManagement.Domain.Qualifications.Dtos;
using FacultyManagement.Domain.Qualifications.Services;
using FacultyManagement.Exceptions;
using FacultyManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetQualificationList
{
    public sealed record Query(QualificationParametersDto QueryParameters) : IRequest<PagedList<QualificationDto>>;

    public sealed class Handler(IQualificationRepository qualificationRepository)
        : IRequestHandler<Query, PagedList<QualificationDto>>
    {
        public async Task<PagedList<QualificationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = qualificationRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToQualificationDtoQueryable();

            return await PagedList<QualificationDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}