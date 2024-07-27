namespace CourseManagement.SharedTestHelpers.Fakes.Enrollment;

using AutoBogus;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Dtos;

public sealed class FakeEnrollmentForCreationDto : AutoFaker<EnrollmentForCreationDto>
{
    public FakeEnrollmentForCreationDto()
    {
    }
}