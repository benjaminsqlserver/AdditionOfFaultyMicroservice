namespace CourseManagement.Domain.Resources.DomainEvents;

public sealed class ResourceUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            