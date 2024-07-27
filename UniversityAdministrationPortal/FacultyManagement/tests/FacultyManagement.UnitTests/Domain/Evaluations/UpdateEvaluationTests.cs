namespace FacultyManagement.UnitTests.Domain.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class UpdateEvaluationTests
{
    private readonly Faker _faker;

    public UpdateEvaluationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_evaluation()
    {
        // Arrange
        var evaluation = new FakeEvaluationBuilder().Build();
        var updatedEvaluation = new FakeEvaluationForUpdate().Generate();
        
        // Act
        evaluation.Update(updatedEvaluation);

        // Assert
        evaluation.FacultyID.Should().Be(updatedEvaluation.FacultyID);
        evaluation.EvaluationDate.Should().BeCloseTo(updatedEvaluation.EvaluationDate, 1.Seconds());
        evaluation.Evaluator.Should().Be(updatedEvaluation.Evaluator);
        evaluation.Comments.Should().Be(updatedEvaluation.Comments);
        evaluation.Rating.Should().Be(updatedEvaluation.Rating);
        evaluation.EvaluatorID.Should().Be(updatedEvaluation.EvaluatorID);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var evaluation = new FakeEvaluationBuilder().Build();
        var updatedEvaluation = new FakeEvaluationForUpdate().Generate();
        evaluation.DomainEvents.Clear();
        
        // Act
        evaluation.Update(updatedEvaluation);

        // Assert
        evaluation.DomainEvents.Count.Should().Be(1);
        evaluation.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(EvaluationUpdated));
    }
}