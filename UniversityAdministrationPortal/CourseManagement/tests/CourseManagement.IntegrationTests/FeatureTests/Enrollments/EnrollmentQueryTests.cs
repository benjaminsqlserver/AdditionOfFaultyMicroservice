namespace CourseManagement.IntegrationTests.FeatureTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.Domain.Enrollments.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class EnrollmentQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_enrollment_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var enrollmentOne = new FakeEnrollmentBuilder().Build();
        await testingServiceScope.InsertAsync(enrollmentOne);

        // Act
        var query = new GetEnrollment.Query(enrollmentOne.Id);
        var enrollment = await testingServiceScope.SendAsync(query);

        // Assert
        enrollment.EnrollmentDate.Should().BeCloseTo(enrollmentOne.EnrollmentDate, 1.Seconds());
        enrollment.StudentID.Should().Be(enrollmentOne.StudentID);
        enrollment.CourseID.Should().Be(enrollmentOne.CourseID);
    }

    [Fact]
    public async Task get_enrollment_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetEnrollment.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}