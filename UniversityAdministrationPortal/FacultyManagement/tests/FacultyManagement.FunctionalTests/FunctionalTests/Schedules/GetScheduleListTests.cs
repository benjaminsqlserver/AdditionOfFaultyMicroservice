namespace FacultyManagement.FunctionalTests.FunctionalTests.Schedules;

using FacultyManagement.SharedTestHelpers.Fakes.Schedule;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetScheduleListTests : TestBase
{
    [Fact]
    public async Task get_schedule_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Schedules.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}