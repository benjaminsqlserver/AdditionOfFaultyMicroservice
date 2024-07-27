namespace FacultyManagement.FunctionalTests.FunctionalTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateQualificationRecordTests : TestBase
{
    [Fact]
    public async Task put_qualification_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var qualification = new FakeQualificationBuilder().Build();
        var updatedQualificationDto = new FakeQualificationForUpdateDto().Generate();
        await InsertAsync(qualification);

        // Act
        var route = ApiRoutes.Qualifications.Put(qualification.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedQualificationDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}