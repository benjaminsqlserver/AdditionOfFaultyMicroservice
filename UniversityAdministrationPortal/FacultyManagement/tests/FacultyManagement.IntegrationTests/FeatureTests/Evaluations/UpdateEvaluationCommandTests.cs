namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.Domain.Evaluations.Dtos;
using FacultyManagement.Domain.Evaluations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateEvaluationCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_evaluation_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluation = new FakeEvaluationBuilder().Build();
        await testingServiceScope.InsertAsync(evaluation);
        var updatedEvaluationDto = new FakeEvaluationForUpdateDto().Generate();

        // Act
        var command = new UpdateEvaluation.Command(evaluation.Id, updatedEvaluationDto);
        await testingServiceScope.SendAsync(command);
        var updatedEvaluation = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Evaluations
                .FirstOrDefaultAsync(e => e.Id == evaluation.Id));

        // Assert
        updatedEvaluation.FacultyID.Should().Be(updatedEvaluationDto.FacultyID);
        updatedEvaluation.EvaluationDate.Should().BeCloseTo(updatedEvaluationDto.EvaluationDate, 1.Seconds());
        updatedEvaluation.Evaluator.Should().Be(updatedEvaluationDto.Evaluator);
        updatedEvaluation.Comments.Should().Be(updatedEvaluationDto.Comments);
        updatedEvaluation.Rating.Should().Be(updatedEvaluationDto.Rating);
        updatedEvaluation.EvaluatorID.Should().Be(updatedEvaluationDto.EvaluatorID);
    }
}