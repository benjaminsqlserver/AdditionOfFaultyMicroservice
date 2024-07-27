namespace FacultyManagement.Domain.Evaluations.Dtos;

using Destructurama.Attributed;

public sealed record EvaluationDto
{
    public Guid Id { get; set; }
    public Guid FacultyID { get; set; }
    public DateTime EvaluationDate { get; set; }
    public string Evaluator { get; set; }
    public string Comments { get; set; }
    public int Rating { get; set; }
    public Guid EvaluatorID { get; set; }
}
