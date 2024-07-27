namespace FacultyManagement.SharedTestHelpers.Fakes.Course;

using AutoBogus;
using FacultyManagement.Domain.Courses;
using FacultyManagement.Domain.Courses.Models;

public sealed class FakeCourseForUpdate : AutoFaker<CourseForUpdate>
{
    public FakeCourseForUpdate()
    {
    }
}