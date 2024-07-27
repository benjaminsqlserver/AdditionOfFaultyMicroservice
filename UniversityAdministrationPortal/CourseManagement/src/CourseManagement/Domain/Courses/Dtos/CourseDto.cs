namespace CourseManagement.Domain.Courses.Dtos;

using Destructurama.Attributed;

public sealed record CourseDto
{
    public Guid Id { get; set; }
    public string CourseName { get; set; }
    public string Syllabus { get; set; }
    public int Credits { get; set; }

}
