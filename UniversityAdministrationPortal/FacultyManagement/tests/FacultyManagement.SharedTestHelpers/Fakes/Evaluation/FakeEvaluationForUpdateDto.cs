namespace FacultyManagement.SharedTestHelpers.Fakes.Evaluation;

using AutoBogus;
using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.Dtos;

public sealed class FakeEvaluationForUpdateDto : AutoFaker<EvaluationForUpdateDto>
{
    public FakeEvaluationForUpdateDto()
    {
    }
}