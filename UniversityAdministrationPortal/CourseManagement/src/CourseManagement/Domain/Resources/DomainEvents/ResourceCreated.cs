namespace CourseManagement.Domain.Resources.DomainEvents;

public sealed class ResourceCreated : DomainEvent
{
    public Resource Resource { get; set; } 
}
            