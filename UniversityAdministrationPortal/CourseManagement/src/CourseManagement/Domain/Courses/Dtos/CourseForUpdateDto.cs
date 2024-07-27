namespace CourseManagement.Domain.Courses.Dtos;

using Destructurama.Attributed;

public sealed record CourseForUpdateDto
{
    public string CourseName { get; set; }
    public string Syllabus { get; set; }
    public int Credits { get; set; }

}
