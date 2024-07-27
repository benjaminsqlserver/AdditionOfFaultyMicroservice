namespace FacultyManagement.Domain.Courses.Models;

using Destructurama.Attributed;

public sealed record CourseForCreation
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }

}
