namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetEvaluationListTests : TestBase
{
    [Fact]
    public async Task get_evaluation_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Evaluations.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}