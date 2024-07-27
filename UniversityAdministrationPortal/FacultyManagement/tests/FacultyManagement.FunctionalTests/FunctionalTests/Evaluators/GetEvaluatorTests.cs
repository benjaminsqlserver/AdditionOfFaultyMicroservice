namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetEvaluatorTests : TestBase
{
    [Fact]
    public async Task get_evaluator_returns_success_when_entity_exists()
    {
        // Arrange
        var evaluator = new FakeEvaluatorBuilder().Build();
        await InsertAsync(evaluator);

        // Act
        var route = ApiRoutes.Evaluators.GetRecord(evaluator.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}