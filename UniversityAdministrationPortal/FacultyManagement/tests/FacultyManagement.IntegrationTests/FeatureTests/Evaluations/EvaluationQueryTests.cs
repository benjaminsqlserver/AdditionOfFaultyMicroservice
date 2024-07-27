namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.Domain.Evaluations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class EvaluationQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_evaluation_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluationOne = new FakeEvaluationBuilder().Build();
        await testingServiceScope.InsertAsync(evaluationOne);

        // Act
        var query = new GetEvaluation.Query(evaluationOne.Id);
        var evaluation = await testingServiceScope.SendAsync(query);

        // Assert
        evaluation.FacultyID.Should().Be(evaluationOne.FacultyID);
        evaluation.EvaluationDate.Should().BeCloseTo(evaluationOne.EvaluationDate, 1.Seconds());
        evaluation.Evaluator.Should().Be(evaluationOne.Evaluator);
        evaluation.Comments.Should().Be(evaluationOne.Comments);
        evaluation.Rating.Should().Be(evaluationOne.Rating);
        evaluation.EvaluatorID.Should().Be(evaluationOne.EvaluatorID);
    }

    [Fact]
    public async Task get_evaluation_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetEvaluation.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}