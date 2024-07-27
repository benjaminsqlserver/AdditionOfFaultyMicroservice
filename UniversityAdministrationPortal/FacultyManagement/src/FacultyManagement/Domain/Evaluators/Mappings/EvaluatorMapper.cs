namespace FacultyManagement.Domain.Evaluators.Mappings;

using FacultyManagement.Domain.Evaluators.Dtos;
using FacultyManagement.Domain.Evaluators.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class EvaluatorMapper
{
    public static partial EvaluatorForCreation ToEvaluatorForCreation(this EvaluatorForCreationDto evaluatorForCreationDto);
    public static partial EvaluatorForUpdate ToEvaluatorForUpdate(this EvaluatorForUpdateDto evaluatorForUpdateDto);
    public static partial EvaluatorDto ToEvaluatorDto(this Evaluator evaluator);
    public static partial IQueryable<EvaluatorDto> ToEvaluatorDtoQueryable(this IQueryable<Evaluator> evaluator);
}