namespace FacultyManagement.SharedTestHelpers.Fakes.Course;

using AutoBogus;
using FacultyManagement.Domain.Courses;
using FacultyManagement.Domain.Courses.Models;

public sealed class FakeCourseForCreation : AutoFaker<CourseForCreation>
{
    public FakeCourseForCreation()
    {
    }
}