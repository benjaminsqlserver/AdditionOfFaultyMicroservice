namespace CourseManagement.IntegrationTests.FeatureTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CourseManagement.Domain.Enrollments.Features;

public class AddEnrollmentCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_enrollment_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var enrollmentOne = new FakeEnrollmentForCreationDto().Generate();

        // Act
        var command = new AddEnrollment.Command(enrollmentOne);
        var enrollmentReturned = await testingServiceScope.SendAsync(command);
        var enrollmentCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Enrollments
            .FirstOrDefaultAsync(e => e.Id == enrollmentReturned.Id));

        // Assert
        enrollmentReturned.EnrollmentDate.Should().BeCloseTo(enrollmentOne.EnrollmentDate, 1.Seconds());
        enrollmentReturned.StudentID.Should().Be(enrollmentOne.StudentID);
        enrollmentReturned.CourseID.Should().Be(enrollmentOne.CourseID);

        enrollmentCreated.EnrollmentDate.Should().BeCloseTo(enrollmentOne.EnrollmentDate, 1.Seconds());
        enrollmentCreated.StudentID.Should().Be(enrollmentOne.StudentID);
        enrollmentCreated.CourseID.Should().Be(enrollmentOne.CourseID);
    }
}