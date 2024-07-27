namespace CourseManagement.SharedTestHelpers.Fakes.Enrollment;

using AutoBogus;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Models;

public sealed class FakeEnrollmentForCreation : AutoFaker<EnrollmentForCreation>
{
    public FakeEnrollmentForCreation()
    {
    }
}