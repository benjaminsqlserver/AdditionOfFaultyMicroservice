namespace FacultyManagement.Domain.Courses.Dtos;

using Destructurama.Attributed;

public sealed record CourseForCreationDto
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }

}
