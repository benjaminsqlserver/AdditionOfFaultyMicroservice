namespace FacultyManagement.Domain.Evaluations.DomainEvents;

public sealed class EvaluationUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            