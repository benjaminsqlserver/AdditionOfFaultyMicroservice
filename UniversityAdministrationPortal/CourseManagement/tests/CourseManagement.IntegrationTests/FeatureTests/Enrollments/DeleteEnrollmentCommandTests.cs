namespace CourseManagement.IntegrationTests.FeatureTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.Domain.Enrollments.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteEnrollmentCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_enrollment_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var enrollment = new FakeEnrollmentBuilder().Build();
        await testingServiceScope.InsertAsync(enrollment);

        // Act
        var command = new DeleteEnrollment.Command(enrollment.Id);
        await testingServiceScope.SendAsync(command);
        var enrollmentResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Enrollments
                .CountAsync(e => e.Id == enrollment.Id));

        // Assert
        enrollmentResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_enrollment_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteEnrollment.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_enrollment_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var enrollment = new FakeEnrollmentBuilder().Build();
        await testingServiceScope.InsertAsync(enrollment);

        // Act
        var command = new DeleteEnrollment.Command(enrollment.Id);
        await testingServiceScope.SendAsync(command);
        var deletedEnrollment = await testingServiceScope.ExecuteDbContextAsync(db => db.Enrollments
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == enrollment.Id));

        // Assert
        deletedEnrollment?.IsDeleted.Should().BeTrue();
    }
}