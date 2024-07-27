namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FacultyManagement.Domain.Evaluators.Features;

public class AddEvaluatorCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_evaluator_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluatorOne = new FakeEvaluatorForCreationDto().Generate();

        // Act
        var command = new AddEvaluator.Command(evaluatorOne);
        var evaluatorReturned = await testingServiceScope.SendAsync(command);
        var evaluatorCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Evaluators
            .FirstOrDefaultAsync(e => e.Id == evaluatorReturned.Id));

        // Assert
        evaluatorReturned.EvaluatorName.Should().Be(evaluatorOne.EvaluatorName);
        evaluatorReturned.EvaluatorEmail.Should().Be(evaluatorOne.EvaluatorEmail);

        evaluatorCreated.EvaluatorName.Should().Be(evaluatorOne.EvaluatorName);
        evaluatorCreated.EvaluatorEmail.Should().Be(evaluatorOne.EvaluatorEmail);
    }
}