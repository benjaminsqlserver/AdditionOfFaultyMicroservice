namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetEvaluationTests : TestBase
{
    [Fact]
    public async Task get_evaluation_returns_success_when_entity_exists()
    {
        // Arrange
        var evaluation = new FakeEvaluationBuilder().Build();
        await InsertAsync(evaluation);

        // Act
        var route = ApiRoutes.Evaluations.GetRecord(evaluation.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}