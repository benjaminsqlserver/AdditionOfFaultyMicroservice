namespace CourseManagement.Domain.Prerequisites.DomainEvents;

public sealed class PrerequisiteCreated : DomainEvent
{
    public Prerequisite Prerequisite { get; set; } 
}
            