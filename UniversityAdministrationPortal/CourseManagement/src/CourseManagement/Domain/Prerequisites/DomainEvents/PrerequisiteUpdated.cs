namespace CourseManagement.Domain.Prerequisites.DomainEvents;

public sealed class PrerequisiteUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            