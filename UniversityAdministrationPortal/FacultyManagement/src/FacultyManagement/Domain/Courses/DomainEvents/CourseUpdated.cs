namespace FacultyManagement.Domain.Courses.DomainEvents;

public sealed class CourseUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            