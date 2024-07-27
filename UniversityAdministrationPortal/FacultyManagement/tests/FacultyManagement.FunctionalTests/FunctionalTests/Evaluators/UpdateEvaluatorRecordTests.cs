namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateEvaluatorRecordTests : TestBase
{
    [Fact]
    public async Task put_evaluator_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var evaluator = new FakeEvaluatorBuilder().Build();
        var updatedEvaluatorDto = new FakeEvaluatorForUpdateDto().Generate();
        await InsertAsync(evaluator);

        // Act
        var route = ApiRoutes.Evaluators.Put(evaluator.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedEvaluatorDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}