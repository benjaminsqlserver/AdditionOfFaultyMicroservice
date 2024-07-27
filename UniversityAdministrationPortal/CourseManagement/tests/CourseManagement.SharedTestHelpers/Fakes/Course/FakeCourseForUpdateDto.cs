namespace CourseManagement.SharedTestHelpers.Fakes.Course;

using AutoBogus;
using CourseManagement.Domain.Courses;
using CourseManagement.Domain.Courses.Dtos;

public sealed class FakeCourseForUpdateDto : AutoFaker<CourseForUpdateDto>
{
    public FakeCourseForUpdateDto()
    {
    }
}