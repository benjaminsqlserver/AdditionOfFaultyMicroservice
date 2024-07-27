namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteEvaluatorTests : TestBase
{
    [Fact]
    public async Task delete_evaluator_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var evaluator = new FakeEvaluatorBuilder().Build();
        await InsertAsync(evaluator);

        // Act
        var route = ApiRoutes.Evaluators.Delete(evaluator.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}