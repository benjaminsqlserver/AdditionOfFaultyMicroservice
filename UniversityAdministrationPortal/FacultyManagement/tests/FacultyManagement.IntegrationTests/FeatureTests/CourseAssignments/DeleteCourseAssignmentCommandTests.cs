namespace FacultyManagement.IntegrationTests.FeatureTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.Domain.CourseAssignments.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteCourseAssignmentCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_courseassignment_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseAssignment = new FakeCourseAssignmentBuilder().Build();
        await testingServiceScope.InsertAsync(courseAssignment);

        // Act
        var command = new DeleteCourseAssignment.Command(courseAssignment.Id);
        await testingServiceScope.SendAsync(command);
        var courseAssignmentResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.CourseAssignments
                .CountAsync(c => c.Id == courseAssignment.Id));

        // Assert
        courseAssignmentResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_courseassignment_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteCourseAssignment.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_courseassignment_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseAssignment = new FakeCourseAssignmentBuilder().Build();
        await testingServiceScope.InsertAsync(courseAssignment);

        // Act
        var command = new DeleteCourseAssignment.Command(courseAssignment.Id);
        await testingServiceScope.SendAsync(command);
        var deletedCourseAssignment = await testingServiceScope.ExecuteDbContextAsync(db => db.CourseAssignments
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == courseAssignment.Id));

        // Assert
        deletedCourseAssignment?.IsDeleted.Should().BeTrue();
    }
}