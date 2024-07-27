namespace FacultyManagement.Domain.Evaluators.Features;

using FacultyManagement.Domain.Evaluators.Dtos;
using FacultyManagement.Domain.Evaluators.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetEvaluator
{
    public sealed record Query(Guid EvaluatorId) : IRequest<EvaluatorDto>;

    public sealed class Handler(IEvaluatorRepository evaluatorRepository)
        : IRequestHandler<Query, EvaluatorDto>
    {
        public async Task<EvaluatorDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await evaluatorRepository.GetById(request.EvaluatorId, cancellationToken: cancellationToken);
            return result.ToEvaluatorDto();
        }
    }
}