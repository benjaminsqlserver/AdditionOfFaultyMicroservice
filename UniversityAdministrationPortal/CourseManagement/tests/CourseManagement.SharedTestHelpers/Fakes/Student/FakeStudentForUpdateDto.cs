namespace CourseManagement.SharedTestHelpers.Fakes.Student;

using AutoBogus;
using CourseManagement.Domain.Students;
using CourseManagement.Domain.Students.Dtos;

public sealed class FakeStudentForUpdateDto : AutoFaker<StudentForUpdateDto>
{
    public FakeStudentForUpdateDto()
    {
    }
}