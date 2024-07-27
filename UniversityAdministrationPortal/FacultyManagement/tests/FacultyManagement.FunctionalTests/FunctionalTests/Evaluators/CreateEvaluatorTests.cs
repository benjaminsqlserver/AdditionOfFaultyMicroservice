namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateEvaluatorTests : TestBase
{
    [Fact]
    public async Task create_evaluator_returns_created_using_valid_dto()
    {
        // Arrange
        var evaluator = new FakeEvaluatorForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Evaluators.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, evaluator);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}