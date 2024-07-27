namespace FacultyManagement.SharedTestHelpers.Fakes.Evaluator;

using AutoBogus;
using FacultyManagement.Domain.Evaluators;
using FacultyManagement.Domain.Evaluators.Models;

public sealed class FakeEvaluatorForCreation : AutoFaker<EvaluatorForCreation>
{
    public FakeEvaluatorForCreation()
    {
    }
}