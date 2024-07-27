namespace CourseManagement.Domain.Prerequisites.Dtos;

using Destructurama.Attributed;

public sealed record PrerequisiteDto
{
    public Guid Id { get; set; }
    public Guid CourseID { get; set; }
    public Guid PrerequisiteCourseID { get; set; }
}
