namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluators;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetEvaluatorListTests : TestBase
{
    [Fact]
    public async Task get_evaluator_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Evaluators.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}