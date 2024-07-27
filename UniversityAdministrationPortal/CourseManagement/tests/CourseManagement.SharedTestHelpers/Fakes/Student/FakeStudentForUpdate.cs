namespace CourseManagement.SharedTestHelpers.Fakes.Student;

using AutoBogus;
using CourseManagement.Domain.Students;
using CourseManagement.Domain.Students.Models;

public sealed class FakeStudentForUpdate : AutoFaker<StudentForUpdate>
{
    public FakeStudentForUpdate()
    {
    }
}