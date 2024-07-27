namespace FacultyManagement.SharedTestHelpers.Fakes.Evaluation;

using AutoBogus;
using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.Models;

public sealed class FakeEvaluationForCreation : AutoFaker<EvaluationForCreation>
{
    public FakeEvaluationForCreation()
    {
    }
}