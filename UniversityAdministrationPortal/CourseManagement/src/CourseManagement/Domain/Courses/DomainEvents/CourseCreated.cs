namespace CourseManagement.Domain.Courses.DomainEvents;

public sealed class CourseCreated : DomainEvent
{
    public Course Course { get; set; } 
}
            