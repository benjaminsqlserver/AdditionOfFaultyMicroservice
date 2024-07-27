namespace CourseManagement.Domain.Enrollments.DomainEvents;

public sealed class EnrollmentCreated : DomainEvent
{
    public Enrollment Enrollment { get; set; } 
}
            