namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.Domain.Evaluators.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class EvaluatorQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_evaluator_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluatorOne = new FakeEvaluatorBuilder().Build();
        await testingServiceScope.InsertAsync(evaluatorOne);

        // Act
        var query = new GetEvaluator.Query(evaluatorOne.Id);
        var evaluator = await testingServiceScope.SendAsync(query);

        // Assert
        evaluator.EvaluatorName.Should().Be(evaluatorOne.EvaluatorName);
        evaluator.EvaluatorEmail.Should().Be(evaluatorOne.EvaluatorEmail);
    }

    [Fact]
    public async Task get_evaluator_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetEvaluator.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}