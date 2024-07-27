namespace FacultyManagement.Domain.Evaluations.Features;

using FacultyManagement.Domain.Evaluations.Dtos;
using FacultyManagement.Domain.Evaluations.Services;
using FacultyManagement.Exceptions;
using FacultyManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetEvaluationList
{
    public sealed record Query(EvaluationParametersDto QueryParameters) : IRequest<PagedList<EvaluationDto>>;

    public sealed class Handler(IEvaluationRepository evaluationRepository)
        : IRequestHandler<Query, PagedList<EvaluationDto>>
    {
        public async Task<PagedList<EvaluationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = evaluationRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToEvaluationDtoQueryable();

            return await PagedList<EvaluationDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}