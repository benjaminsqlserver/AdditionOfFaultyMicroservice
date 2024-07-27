namespace FacultyManagement.UnitTests.Domain.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.Domain.Evaluators;
using FacultyManagement.Domain.Evaluators.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class CreateEvaluatorTests
{
    private readonly Faker _faker;

    public CreateEvaluatorTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_evaluator()
    {
        // Arrange
        var evaluatorToCreate = new FakeEvaluatorForCreation().Generate();
        
        // Act
        var evaluator = Evaluator.Create(evaluatorToCreate);

        // Assert
        evaluator.EvaluatorName.Should().Be(evaluatorToCreate.EvaluatorName);
        evaluator.EvaluatorEmail.Should().Be(evaluatorToCreate.EvaluatorEmail);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var evaluatorToCreate = new FakeEvaluatorForCreation().Generate();
        
        // Act
        var evaluator = Evaluator.Create(evaluatorToCreate);

        // Assert
        evaluator.DomainEvents.Count.Should().Be(1);
        evaluator.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(EvaluatorCreated));
    }
}