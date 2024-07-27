namespace FacultyManagement.Domain.Evaluators.DomainEvents;

public sealed class EvaluatorUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            