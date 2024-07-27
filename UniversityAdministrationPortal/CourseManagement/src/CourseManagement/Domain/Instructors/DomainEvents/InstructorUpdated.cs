namespace CourseManagement.Domain.Instructors.DomainEvents;

public sealed class InstructorUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            