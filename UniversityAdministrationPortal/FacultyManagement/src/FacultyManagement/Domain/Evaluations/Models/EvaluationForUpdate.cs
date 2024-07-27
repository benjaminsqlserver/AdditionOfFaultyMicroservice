namespace FacultyManagement.Domain.Evaluations.Models;

using Destructurama.Attributed;

public sealed record EvaluationForUpdate
{
    public Guid FacultyID { get; set; }
    public DateTime EvaluationDate { get; set; }
    public string Evaluator { get; set; }
    public string Comments { get; set; }
    public int Rating { get; set; }
    public Guid EvaluatorID { get; set; }
}
