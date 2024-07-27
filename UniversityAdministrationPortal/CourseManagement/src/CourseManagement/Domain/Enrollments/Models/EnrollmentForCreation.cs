namespace CourseManagement.Domain.Enrollments.Models;

using Destructurama.Attributed;

public sealed record EnrollmentForCreation
{
    public DateTime EnrollmentDate { get; set; }
    public Guid StudentID { get; set; }
    public Guid CourseID { get; set; }
}
