namespace CourseManagement.SharedTestHelpers.Fakes.Enrollment;

using AutoBogus;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Models;

public sealed class FakeEnrollmentForUpdate : AutoFaker<EnrollmentForUpdate>
{
    public FakeEnrollmentForUpdate()
    {
    }
}