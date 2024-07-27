namespace CourseManagement.SharedTestHelpers.Fakes.Instructor;

using AutoBogus;
using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Instructors.Models;

public sealed class FakeInstructorForCreation : AutoFaker<InstructorForCreation>
{
    public FakeInstructorForCreation()
    {
    }
}