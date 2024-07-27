namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FacultyManagement.Domain.Evaluations.Features;

public class AddEvaluationCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_evaluation_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluationOne = new FakeEvaluationForCreationDto().Generate();

        // Act
        var command = new AddEvaluation.Command(evaluationOne);
        var evaluationReturned = await testingServiceScope.SendAsync(command);
        var evaluationCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Evaluations
            .FirstOrDefaultAsync(e => e.Id == evaluationReturned.Id));

        // Assert
        evaluationReturned.FacultyID.Should().Be(evaluationOne.FacultyID);
        evaluationReturned.EvaluationDate.Should().BeCloseTo(evaluationOne.EvaluationDate, 1.Seconds());
        evaluationReturned.Evaluator.Should().Be(evaluationOne.Evaluator);
        evaluationReturned.Comments.Should().Be(evaluationOne.Comments);
        evaluationReturned.Rating.Should().Be(evaluationOne.Rating);
        evaluationReturned.EvaluatorID.Should().Be(evaluationOne.EvaluatorID);

        evaluationCreated.FacultyID.Should().Be(evaluationOne.FacultyID);
        evaluationCreated.EvaluationDate.Should().BeCloseTo(evaluationOne.EvaluationDate, 1.Seconds());
        evaluationCreated.Evaluator.Should().Be(evaluationOne.Evaluator);
        evaluationCreated.Comments.Should().Be(evaluationOne.Comments);
        evaluationCreated.Rating.Should().Be(evaluationOne.Rating);
        evaluationCreated.EvaluatorID.Should().Be(evaluationOne.EvaluatorID);
    }
}