namespace FacultyManagement.UnitTests.Domain.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.Domain.Evaluators;
using FacultyManagement.Domain.Evaluators.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class UpdateEvaluatorTests
{
    private readonly Faker _faker;

    public UpdateEvaluatorTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_evaluator()
    {
        // Arrange
        var evaluator = new FakeEvaluatorBuilder().Build();
        var updatedEvaluator = new FakeEvaluatorForUpdate().Generate();
        
        // Act
        evaluator.Update(updatedEvaluator);

        // Assert
        evaluator.EvaluatorName.Should().Be(updatedEvaluator.EvaluatorName);
        evaluator.EvaluatorEmail.Should().Be(updatedEvaluator.EvaluatorEmail);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var evaluator = new FakeEvaluatorBuilder().Build();
        var updatedEvaluator = new FakeEvaluatorForUpdate().Generate();
        evaluator.DomainEvents.Clear();
        
        // Act
        evaluator.Update(updatedEvaluator);

        // Assert
        evaluator.DomainEvents.Count.Should().Be(1);
        evaluator.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(EvaluatorUpdated));
    }
}