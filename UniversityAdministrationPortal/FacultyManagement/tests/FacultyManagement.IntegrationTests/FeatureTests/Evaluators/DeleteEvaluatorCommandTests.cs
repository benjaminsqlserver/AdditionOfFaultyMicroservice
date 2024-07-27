namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.Domain.Evaluators.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteEvaluatorCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_evaluator_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluator = new FakeEvaluatorBuilder().Build();
        await testingServiceScope.InsertAsync(evaluator);

        // Act
        var command = new DeleteEvaluator.Command(evaluator.Id);
        await testingServiceScope.SendAsync(command);
        var evaluatorResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Evaluators
                .CountAsync(e => e.Id == evaluator.Id));

        // Assert
        evaluatorResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_evaluator_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteEvaluator.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_evaluator_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluator = new FakeEvaluatorBuilder().Build();
        await testingServiceScope.InsertAsync(evaluator);

        // Act
        var command = new DeleteEvaluator.Command(evaluator.Id);
        await testingServiceScope.SendAsync(command);
        var deletedEvaluator = await testingServiceScope.ExecuteDbContextAsync(db => db.Evaluators
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == evaluator.Id));

        // Assert
        deletedEvaluator?.IsDeleted.Should().BeTrue();
    }
}