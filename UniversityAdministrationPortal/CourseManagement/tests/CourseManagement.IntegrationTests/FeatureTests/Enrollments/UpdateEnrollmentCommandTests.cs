namespace CourseManagement.IntegrationTests.FeatureTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.Domain.Enrollments.Dtos;
using CourseManagement.Domain.Enrollments.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateEnrollmentCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_enrollment_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var enrollment = new FakeEnrollmentBuilder().Build();
        await testingServiceScope.InsertAsync(enrollment);
        var updatedEnrollmentDto = new FakeEnrollmentForUpdateDto().Generate();

        // Act
        var command = new UpdateEnrollment.Command(enrollment.Id, updatedEnrollmentDto);
        await testingServiceScope.SendAsync(command);
        var updatedEnrollment = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Enrollments
                .FirstOrDefaultAsync(e => e.Id == enrollment.Id));

        // Assert
        updatedEnrollment.EnrollmentDate.Should().BeCloseTo(updatedEnrollmentDto.EnrollmentDate, 1.Seconds());
        updatedEnrollment.StudentID.Should().Be(updatedEnrollmentDto.StudentID);
        updatedEnrollment.CourseID.Should().Be(updatedEnrollmentDto.CourseID);
    }
}