namespace FacultyManagement.Domain.Evaluations.Features;

using FacultyManagement.Domain.Evaluations.Dtos;
using FacultyManagement.Domain.Evaluations.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetEvaluation
{
    public sealed record Query(Guid EvaluationId) : IRequest<EvaluationDto>;

    public sealed class Handler(IEvaluationRepository evaluationRepository)
        : IRequestHandler<Query, EvaluationDto>
    {
        public async Task<EvaluationDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await evaluationRepository.GetById(request.EvaluationId, cancellationToken: cancellationToken);
            return result.ToEvaluationDto();
        }
    }
}