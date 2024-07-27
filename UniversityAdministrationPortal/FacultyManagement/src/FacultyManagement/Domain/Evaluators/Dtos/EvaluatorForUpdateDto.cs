namespace FacultyManagement.Domain.Evaluators.Dtos;

using Destructurama.Attributed;

public sealed record EvaluatorForUpdateDto
{
    public string EvaluatorName { get; set; }
    public string EvaluatorEmail { get; set; }
}
