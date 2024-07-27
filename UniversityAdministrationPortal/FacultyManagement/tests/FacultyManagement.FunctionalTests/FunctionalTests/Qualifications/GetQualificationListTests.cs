namespace FacultyManagement.FunctionalTests.FunctionalTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetQualificationListTests : TestBase
{
    [Fact]
    public async Task get_qualification_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Qualifications.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}