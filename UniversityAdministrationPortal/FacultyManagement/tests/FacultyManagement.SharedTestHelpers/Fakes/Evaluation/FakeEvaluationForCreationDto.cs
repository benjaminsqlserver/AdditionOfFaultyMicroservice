namespace FacultyManagement.SharedTestHelpers.Fakes.Evaluation;

using AutoBogus;
using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.Dtos;

public sealed class FakeEvaluationForCreationDto : AutoFaker<EvaluationForCreationDto>
{
    public FakeEvaluationForCreationDto()
    {
    }
}