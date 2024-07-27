namespace CourseManagement.UnitTests.Domain.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class UpdateEnrollmentTests
{
    private readonly Faker _faker;

    public UpdateEnrollmentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_enrollment()
    {
        // Arrange
        var enrollment = new FakeEnrollmentBuilder().Build();
        var updatedEnrollment = new FakeEnrollmentForUpdate().Generate();
        
        // Act
        enrollment.Update(updatedEnrollment);

        // Assert
        enrollment.EnrollmentDate.Should().BeCloseTo(updatedEnrollment.EnrollmentDate, 1.Seconds());
        enrollment.StudentID.Should().Be(updatedEnrollment.StudentID);
        enrollment.CourseID.Should().Be(updatedEnrollment.CourseID);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var enrollment = new FakeEnrollmentBuilder().Build();
        var updatedEnrollment = new FakeEnrollmentForUpdate().Generate();
        enrollment.DomainEvents.Clear();
        
        // Act
        enrollment.Update(updatedEnrollment);

        // Assert
        enrollment.DomainEvents.Count.Should().Be(1);
        enrollment.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(EnrollmentUpdated));
    }
}