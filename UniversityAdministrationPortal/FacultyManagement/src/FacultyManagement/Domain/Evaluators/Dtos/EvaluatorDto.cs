namespace FacultyManagement.Domain.Evaluators.Dtos;

using Destructurama.Attributed;

public sealed record EvaluatorDto
{
    public Guid Id { get; set; }
    public string EvaluatorName { get; set; }
    public string EvaluatorEmail { get; set; }
}
