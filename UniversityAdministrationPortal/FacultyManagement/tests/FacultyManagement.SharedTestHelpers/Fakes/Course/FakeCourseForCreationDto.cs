namespace FacultyManagement.SharedTestHelpers.Fakes.Course;

using AutoBogus;
using FacultyManagement.Domain.Courses;
using FacultyManagement.Domain.Courses.Dtos;

public sealed class FakeCourseForCreationDto : AutoFaker<CourseForCreationDto>
{
    public FakeCourseForCreationDto()
    {
    }
}