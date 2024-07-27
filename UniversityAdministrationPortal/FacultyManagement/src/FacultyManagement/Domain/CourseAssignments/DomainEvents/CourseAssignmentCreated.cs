namespace FacultyManagement.Domain.CourseAssignments.DomainEvents;

public sealed class CourseAssignmentCreated : DomainEvent
{
    public CourseAssignment CourseAssignment { get; set; } 
}
            