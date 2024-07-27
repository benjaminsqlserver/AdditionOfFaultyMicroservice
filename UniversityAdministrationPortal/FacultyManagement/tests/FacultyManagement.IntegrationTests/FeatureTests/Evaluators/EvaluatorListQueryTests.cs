namespace FacultyManagement.IntegrationTests.FeatureTests.Evaluators;

using FacultyManagement.Domain.Evaluators.Dtos;
using FacultyManagement.SharedTestHelpers.Fakes.Evaluator;
using FacultyManagement.Domain.Evaluators.Features;
using Domain;
using System.Threading.Tasks;

public class EvaluatorListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_evaluator_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var evaluatorOne = new FakeEvaluatorBuilder().Build();
        var evaluatorTwo = new FakeEvaluatorBuilder().Build();
        var queryParameters = new EvaluatorParametersDto();

        await testingServiceScope.InsertAsync(evaluatorOne, evaluatorTwo);

        // Act
        var query = new GetEvaluatorList.Query(queryParameters);
        var evaluators = await testingServiceScope.SendAsync(query);

        // Assert
        evaluators.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}