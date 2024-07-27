namespace FacultyManagement.Domain.Evaluations.DomainEvents;

public sealed class EvaluationCreated : DomainEvent
{
    public Evaluation Evaluation { get; set; } 
}
            