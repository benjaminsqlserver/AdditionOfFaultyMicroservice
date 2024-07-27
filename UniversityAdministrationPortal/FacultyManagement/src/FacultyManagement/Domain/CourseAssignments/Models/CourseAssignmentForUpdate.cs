namespace FacultyManagement.Domain.CourseAssignments.Models;

using Destructurama.Attributed;

public sealed record CourseAssignmentForUpdate
{
    public Guid FacultyID { get; set; }
    public Guid CourseID { get; set; }
    public DateTime AssignmentDate { get; set; }
}
