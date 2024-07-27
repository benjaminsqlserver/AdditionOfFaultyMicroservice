namespace CourseManagement.Domain.Courses.Models;

using Destructurama.Attributed;

public sealed record CourseForUpdate
{
    public string CourseName { get; set; }
    public string Syllabus { get; set; }
    public int Credits { get; set; }

}
