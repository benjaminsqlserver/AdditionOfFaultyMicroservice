namespace FacultyManagement.UnitTests.Domain.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class CreateEvaluationTests
{
    private readonly Faker _faker;

    public CreateEvaluationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_evaluation()
    {
        // Arrange
        var evaluationToCreate = new FakeEvaluationForCreation().Generate();
        
        // Act
        var evaluation = Evaluation.Create(evaluationToCreate);

        // Assert
        evaluation.FacultyID.Should().Be(evaluationToCreate.FacultyID);
        evaluation.EvaluationDate.Should().BeCloseTo(evaluationToCreate.EvaluationDate, 1.Seconds());
        evaluation.Evaluator.Should().Be(evaluationToCreate.Evaluator);
        evaluation.Comments.Should().Be(evaluationToCreate.Comments);
        evaluation.Rating.Should().Be(evaluationToCreate.Rating);
        evaluation.EvaluatorID.Should().Be(evaluationToCreate.EvaluatorID);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var evaluationToCreate = new FakeEvaluationForCreation().Generate();
        
        // Act
        var evaluation = Evaluation.Create(evaluationToCreate);

        // Assert
        evaluation.DomainEvents.Count.Should().Be(1);
        evaluation.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(EvaluationCreated));
    }
}