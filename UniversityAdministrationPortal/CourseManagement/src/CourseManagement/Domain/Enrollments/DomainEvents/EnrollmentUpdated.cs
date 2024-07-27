namespace CourseManagement.Domain.Enrollments.DomainEvents;

public sealed class EnrollmentUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            