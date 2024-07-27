namespace FacultyManagement.Domain.Evaluators.DomainEvents;

public sealed class EvaluatorCreated : DomainEvent
{
    public Evaluator Evaluator { get; set; } 
}
            