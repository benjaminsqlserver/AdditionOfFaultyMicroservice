namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.Domain.Evaluations.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteEvaluationCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_evaluation_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluation = new FakeEvaluationBuilder().Build();
        await testingServiceScope.InsertAsync(evaluation);

        // Act
        var command = new DeleteEvaluation.Command(evaluation.Id);
        await testingServiceScope.SendAsync(command);
        var evaluationResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Evaluations
                .CountAsync(e => e.Id == evaluation.Id));

        // Assert
        evaluationResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_evaluation_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteEvaluation.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_evaluation_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluation = new FakeEvaluationBuilder().Build();
        await testingServiceScope.InsertAsync(evaluation);

        // Act
        var command = new DeleteEvaluation.Command(evaluation.Id);
        await testingServiceScope.SendAsync(command);
        var deletedEvaluation = await testingServiceScope.ExecuteDbContextAsync(db => db.Evaluations
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == evaluation.Id));

        // Assert
        deletedEvaluation?.IsDeleted.Should().BeTrue();
    }
}