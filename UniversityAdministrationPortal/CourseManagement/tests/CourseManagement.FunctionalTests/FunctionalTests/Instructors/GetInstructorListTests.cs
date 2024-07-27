namespace CourseManagement.FunctionalTests.FunctionalTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetInstructorListTests : TestBase
{
    [Fact]
    public async Task get_instructor_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Instructors.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}