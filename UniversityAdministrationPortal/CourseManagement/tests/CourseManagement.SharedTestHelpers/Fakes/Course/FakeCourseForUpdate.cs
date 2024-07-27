namespace CourseManagement.SharedTestHelpers.Fakes.Course;

using AutoBogus;
using CourseManagement.Domain.Courses;
using CourseManagement.Domain.Courses.Models;

public sealed class FakeCourseForUpdate : AutoFaker<CourseForUpdate>
{
    public FakeCourseForUpdate()
    {
    }
}