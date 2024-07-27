namespace FacultyManagement.Domain.Evaluations.Mappings;

using FacultyManagement.Domain.Evaluations.Dtos;
using FacultyManagement.Domain.Evaluations.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class EvaluationMapper
{
    public static partial EvaluationForCreation ToEvaluationForCreation(this EvaluationForCreationDto evaluationForCreationDto);
    public static partial EvaluationForUpdate ToEvaluationForUpdate(this EvaluationForUpdateDto evaluationForUpdateDto);
    public static partial EvaluationDto ToEvaluationDto(this Evaluation evaluation);
    public static partial IQueryable<EvaluationDto> ToEvaluationDtoQueryable(this IQueryable<Evaluation> evaluation);
}