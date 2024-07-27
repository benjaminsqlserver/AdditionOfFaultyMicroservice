namespace CourseManagement.IntegrationTests.FeatureTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.Domain.Prerequisites.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeletePrerequisiteCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_prerequisite_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var prerequisite = new FakePrerequisiteBuilder().Build();
        await testingServiceScope.InsertAsync(prerequisite);

        // Act
        var command = new DeletePrerequisite.Command(prerequisite.Id);
        await testingServiceScope.SendAsync(command);
        var prerequisiteResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Prerequisites
                .CountAsync(p => p.Id == prerequisite.Id));

        // Assert
        prerequisiteResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_prerequisite_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeletePrerequisite.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_prerequisite_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var prerequisite = new FakePrerequisiteBuilder().Build();
        await testingServiceScope.InsertAsync(prerequisite);

        // Act
        var command = new DeletePrerequisite.Command(prerequisite.Id);
        await testingServiceScope.SendAsync(command);
        var deletedPrerequisite = await testingServiceScope.ExecuteDbContextAsync(db => db.Prerequisites
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == prerequisite.Id));

        // Assert
        deletedPrerequisite?.IsDeleted.Should().BeTrue();
    }
}