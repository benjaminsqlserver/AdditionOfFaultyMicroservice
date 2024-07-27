namespace FacultyManagement.FunctionalTests.FunctionalTests.Evaluations;

using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateEvaluationRecordTests : TestBase
{
    [Fact]
    public async Task put_evaluation_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var evaluation = new FakeEvaluationBuilder().Build();
        var updatedEvaluationDto = new FakeEvaluationForUpdateDto().Generate();
        await InsertAsync(evaluation);

        // Act
        var route = ApiRoutes.Evaluations.Put(evaluation.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedEvaluationDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}