namespace FacultyManagement.Domain.CourseAssignments.DomainEvents;

public sealed class CourseAssignmentUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            