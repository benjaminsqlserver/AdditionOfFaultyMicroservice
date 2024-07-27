namespace FacultyManagement.Domain.CourseAssignments.Dtos;

using Destructurama.Attributed;

public sealed record CourseAssignmentDto
{
    public Guid Id { get; set; }
    public Guid FacultyID { get; set; }
    public Guid CourseID { get; set; }
    public DateTime AssignmentDate { get; set; }
}
