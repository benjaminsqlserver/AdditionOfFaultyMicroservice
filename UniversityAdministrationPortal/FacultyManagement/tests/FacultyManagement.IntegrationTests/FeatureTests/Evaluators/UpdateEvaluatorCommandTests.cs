namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.Domain.Evaluators.Dtos;
using FacultyManagement.Domain.Evaluators.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateEvaluatorCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_evaluator_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluator = new FakeEvaluatorBuilder().Build();
        await testingServiceScope.InsertAsync(evaluator);
        var updatedEvaluatorDto = new FakeEvaluatorForUpdateDto().Generate();

        // Act
        var command = new UpdateEvaluator.Command(evaluator.Id, updatedEvaluatorDto);
        await testingServiceScope.SendAsync(command);
        var updatedEvaluator = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Evaluators
                .FirstOrDefaultAsync(e => e.Id == evaluator.Id));

        // Assert
        updatedEvaluator.EvaluatorName.Should().Be(updatedEvaluatorDto.EvaluatorName);
        updatedEvaluator.EvaluatorEmail.Should().Be(updatedEvaluatorDto.EvaluatorEmail);
    }
}