namespace CourseManagement.SharedTestHelpers.Fakes.Instructor;

using AutoBogus;
using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Instructors.Dtos;

public sealed class FakeInstructorForUpdateDto : AutoFaker<InstructorForUpdateDto>
{
    public FakeInstructorForUpdateDto()
    {
    }
}