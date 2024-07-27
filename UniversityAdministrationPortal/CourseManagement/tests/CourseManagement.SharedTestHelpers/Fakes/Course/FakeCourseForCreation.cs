namespace CourseManagement.SharedTestHelpers.Fakes.Course;

using AutoBogus;
using CourseManagement.Domain.Courses;
using CourseManagement.Domain.Courses.Models;

public sealed class FakeCourseForCreation : AutoFaker<CourseForCreation>
{
    public FakeCourseForCreation()
    {
    }
}