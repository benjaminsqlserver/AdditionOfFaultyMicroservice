namespace CourseManagement.SharedTestHelpers.Fakes.Instructor;

using AutoBogus;
using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Instructors.Dtos;

public sealed class FakeInstructorForCreationDto : AutoFaker<InstructorForCreationDto>
{
    public FakeInstructorForCreationDto()
    {
    }
}