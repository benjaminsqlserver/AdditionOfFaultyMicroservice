namespace CourseManagement.IntegrationTests.FeatureTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.Domain.Instructors.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteInstructorCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_instructor_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var instructor = new FakeInstructorBuilder().Build();
        await testingServiceScope.InsertAsync(instructor);

        // Act
        var command = new DeleteInstructor.Command(instructor.Id);
        await testingServiceScope.SendAsync(command);
        var instructorResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Instructors
                .CountAsync(i => i.Id == instructor.Id));

        // Assert
        instructorResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_instructor_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteInstructor.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_instructor_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var instructor = new FakeInstructorBuilder().Build();
        await testingServiceScope.InsertAsync(instructor);

        // Act
        var command = new DeleteInstructor.Command(instructor.Id);
        await testingServiceScope.SendAsync(command);
        var deletedInstructor = await testingServiceScope.ExecuteDbContextAsync(db => db.Instructors
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == instructor.Id));

        // Assert
        deletedInstructor?.IsDeleted.Should().BeTrue();
    }
}