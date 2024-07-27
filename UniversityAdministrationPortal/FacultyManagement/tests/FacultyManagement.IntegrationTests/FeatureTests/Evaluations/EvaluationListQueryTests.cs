namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluations;

using FacultyManagement.Domain.Evaluations.Dtos;
using FacultyManagement.SharedTestHelpers.Fakes.Evaluation;
using FacultyManagement.Domain.Evaluations.Features;
using Domain;
using System.Threading.Tasks;

public class EvaluationListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_evaluation_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluationOne = new FakeEvaluationBuilder().Build();
        var evaluationTwo = new FakeEvaluationBuilder().Build();
        var queryParameters = new EvaluationParametersDto();

        await testingServiceScope.InsertAsync(evaluationOne, evaluationTwo);

        // Act
        var query = new GetEvaluationList.Query(queryParameters);
        var evaluations = await testingServiceScope.SendAsync(query);

        // Assert
        evaluations.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}