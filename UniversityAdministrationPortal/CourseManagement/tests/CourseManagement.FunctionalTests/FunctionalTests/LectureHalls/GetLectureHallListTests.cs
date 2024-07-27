namespace CourseManagement.FunctionalTests.FunctionalTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetLectureHallListTests : TestBase
{
    [Fact]
    public async Task get_lecturehall_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.LectureHalls.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}