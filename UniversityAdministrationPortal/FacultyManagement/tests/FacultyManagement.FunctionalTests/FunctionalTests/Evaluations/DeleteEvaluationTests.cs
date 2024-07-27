namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteEvaluationTests : TestBase
{
    [Fact]
    public async Task delete_evaluation_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var evaluation = new FakeEvaluationBuilder().Build();
        await InsertAsync(evaluation);

        // Act
        var route = ApiRoutes.Evaluations.Delete(evaluation.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}