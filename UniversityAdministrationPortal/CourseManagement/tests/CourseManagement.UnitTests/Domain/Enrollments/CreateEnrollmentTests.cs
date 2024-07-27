namespace CourseManagement.UnitTests.Domain.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class CreateEnrollmentTests
{
    private readonly Faker _faker;

    public CreateEnrollmentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_enrollment()
    {
        // Arrange
        var enrollmentToCreate = new FakeEnrollmentForCreation().Generate();
        
        // Act
        var enrollment = Enrollment.Create(enrollmentToCreate);

        // Assert
        enrollment.EnrollmentDate.Should().BeCloseTo(enrollmentToCreate.EnrollmentDate, 1.Seconds());
        enrollment.StudentID.Should().Be(enrollmentToCreate.StudentID);
        enrollment.CourseID.Should().Be(enrollmentToCreate.CourseID);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var enrollmentToCreate = new FakeEnrollmentForCreation().Generate();
        
        // Act
        var enrollment = Enrollment.Create(enrollmentToCreate);

        // Assert
        enrollment.DomainEvents.Count.Should().Be(1);
        enrollment.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(EnrollmentCreated));
    }
}