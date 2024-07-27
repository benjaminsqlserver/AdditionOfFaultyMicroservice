namespace CourseManagement.Domain.Prerequisites.Dtos;

using Destructurama.Attributed;

public sealed record PrerequisiteForCreationDto
{
    public Guid CourseID { get; set; }
    public Guid PrerequisiteCourseID { get; set; }
}
