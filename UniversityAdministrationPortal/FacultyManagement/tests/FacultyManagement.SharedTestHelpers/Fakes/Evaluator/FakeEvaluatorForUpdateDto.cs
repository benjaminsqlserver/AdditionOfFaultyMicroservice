namespace FacultyManagement.SharedTestHelpers.Fakes.Evaluator;

using AutoBogus;
using FacultyManagement.Domain.Evaluators;
using FacultyManagement.Domain.Evaluators.Dtos;

public sealed class FakeEvaluatorForUpdateDto : AutoFaker<EvaluatorForUpdateDto>
{
    public FakeEvaluatorForUpdateDto()
    {
    }
}