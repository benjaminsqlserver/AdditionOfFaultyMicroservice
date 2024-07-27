namespace CourseManagement.FunctionalTests.FunctionalTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateLectureHallTests : TestBase
{
    [Fact]
    public async Task create_lecturehall_returns_created_using_valid_dto()
    {
        // Arrange
        var lectureHall = new FakeLectureHallForCreationDto().Generate();

        // Act
        var route = ApiRoutes.LectureHalls.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, lectureHall);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}