namespace CourseManagement.IntegrationTests.FeatureTests.Resources;

using CourseManagement.Domain.Resources.Dtos;
using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.Domain.Resources.Features;
using Domain;
using System.Threading.Tasks;

public class ResourceListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_resource_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var resourceOne = new FakeResourceBuilder().Build();
        var resourceTwo = new FakeResourceBuilder().Build();
        var queryParameters = new ResourceParametersDto();

        await testingServiceScope.InsertAsync(resourceOne, resourceTwo);

        // Act
        var query = new GetResourceList.Query(queryParameters);
        var resources = await testingServiceScope.SendAsync(query);

        // Assert
        resources.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}