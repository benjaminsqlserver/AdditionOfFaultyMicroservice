namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateEvaluationTests : TestBase
{
    [Fact]
    public async Task create_evaluation_returns_created_using_valid_dto()
    {
        // Arrange
        var evaluation = new FakeEvaluationForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Evaluations.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, evaluation);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}