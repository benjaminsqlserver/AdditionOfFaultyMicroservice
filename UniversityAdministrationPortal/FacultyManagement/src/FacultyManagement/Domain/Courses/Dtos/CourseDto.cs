namespace FacultyManagement.Domain.Courses.Dtos;

using Destructurama.Attributed;

public sealed record CourseDto
{
    public Guid Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }

}
