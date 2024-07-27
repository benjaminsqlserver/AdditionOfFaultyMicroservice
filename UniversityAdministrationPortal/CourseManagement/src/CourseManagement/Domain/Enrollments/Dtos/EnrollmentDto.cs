namespace CourseManagement.Domain.Enrollments.Dtos;

using Destructurama.Attributed;

public sealed record EnrollmentDto
{
    public Guid Id { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public Guid StudentID { get; set; }
    public Guid CourseID { get; set; }
}
