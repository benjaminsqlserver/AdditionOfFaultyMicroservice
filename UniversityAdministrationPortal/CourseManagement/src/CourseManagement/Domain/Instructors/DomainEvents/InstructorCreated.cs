namespace CourseManagement.Domain.Instructors.DomainEvents;

public sealed class InstructorCreated : DomainEvent
{
    public Instructor Instructor { get; set; } 
}
            