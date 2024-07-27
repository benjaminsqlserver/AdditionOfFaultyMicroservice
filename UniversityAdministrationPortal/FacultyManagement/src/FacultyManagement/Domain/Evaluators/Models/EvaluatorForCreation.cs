namespace FacultyManagement.Domain.Evaluators.Models;

using Destructurama.Attributed;

public sealed record EvaluatorForCreation
{
    public string EvaluatorName { get; set; }
    public string EvaluatorEmail { get; set; }
}
