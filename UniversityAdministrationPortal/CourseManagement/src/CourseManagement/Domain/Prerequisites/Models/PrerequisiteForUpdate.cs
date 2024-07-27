namespace CourseManagement.Domain.Prerequisites.Models;

using Destructurama.Attributed;

public sealed record PrerequisiteForUpdate
{
    public Guid CourseID { get; set; }
    public Guid PrerequisiteCourseID { get; set; }
}
