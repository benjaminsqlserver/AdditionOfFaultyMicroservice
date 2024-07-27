namespace FacultyManagement.FunctionalTests.FunctionalTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetQualificationTests : TestBase
{
    [Fact]
    public async Task get_qualification_returns_success_when_entity_exists()
    {
        // Arrange
        var qualification = new FakeQualificationBuilder().Build();
        await InsertAsync(qualification);

        // Act
        var route = ApiRoutes.Qualifications.GetRecord(qualification.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}