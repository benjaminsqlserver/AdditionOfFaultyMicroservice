namespace CourseManagement.IntegrationTests.FeatureTests.Prerequisites;

using CourseManagement.Domain.Prerequisites.Dtos;
using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.Domain.Prerequisites.Features;
using Domain;
using System.Threading.Tasks;

public class PrerequisiteListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_prerequisite_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var prerequisiteOne = new FakePrerequisiteBuilder().Build();
        var prerequisiteTwo = new FakePrerequisiteBuilder().Build();
        var queryParameters = new PrerequisiteParametersDto();

        await testingServiceScope.InsertAsync(prerequisiteOne, prerequisiteTwo);

        // Act
        var query = new GetPrerequisiteList.Query(queryParameters);
        var prerequisites = await testingServiceScope.SendAsync(query);

        // Assert
        prerequisites.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}