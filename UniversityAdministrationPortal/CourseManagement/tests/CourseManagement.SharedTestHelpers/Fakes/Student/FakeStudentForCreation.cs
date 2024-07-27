namespace CourseManagement.SharedTestHelpers.Fakes.Student;

using AutoBogus;
using CourseManagement.Domain.Students;
using CourseManagement.Domain.Students.Models;

public sealed class FakeStudentForCreation : AutoFaker<StudentForCreation>
{
    public FakeStudentForCreation()
    {
    }
}