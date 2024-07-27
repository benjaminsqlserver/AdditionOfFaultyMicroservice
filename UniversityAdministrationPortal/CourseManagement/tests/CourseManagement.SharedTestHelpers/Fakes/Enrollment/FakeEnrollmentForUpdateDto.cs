namespace CourseManagement.SharedTestHelpers.Fakes.Enrollment;

using AutoBogus;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Dtos;

public sealed class FakeEnrollmentForUpdateDto : AutoFaker<EnrollmentForUpdateDto>
{
    public FakeEnrollmentForUpdateDto()
    {
    }
}