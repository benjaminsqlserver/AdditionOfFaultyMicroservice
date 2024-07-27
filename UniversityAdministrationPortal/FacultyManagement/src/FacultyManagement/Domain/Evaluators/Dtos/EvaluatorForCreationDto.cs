namespace FacultyManagement.Domain.Evaluators.Dtos;

using Destructurama.Attributed;

public sealed record EvaluatorForCreationDto
{
    public string EvaluatorName { get; set; }
    public string EvaluatorEmail { get; set; }
}
