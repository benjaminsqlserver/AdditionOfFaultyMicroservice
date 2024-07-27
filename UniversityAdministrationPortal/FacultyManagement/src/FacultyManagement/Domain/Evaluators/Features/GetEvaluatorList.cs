namespace FacultyManagement.Domain.Evaluators.Features;

using FacultyManagement.Domain.Evaluators.Dtos;
using FacultyManagement.Domain.Evaluators.Services;
using FacultyManagement.Exceptions;
using FacultyManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetEvaluatorList
{
    public sealed record Query(EvaluatorParametersDto QueryParameters) : IRequest<PagedList<EvaluatorDto>>;

    public sealed class Handler(IEvaluatorRepository evaluatorRepository)
        : IRequestHandler<Query, PagedList<EvaluatorDto>>
    {
        public async Task<PagedList<EvaluatorDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = evaluatorRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToEvaluatorDtoQueryable();

            return await PagedList<EvaluatorDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}