namespace CourseManagement.FunctionalTests.FunctionalTests.Students;

using CourseManagement.SharedTestHelpers.Fakes.Student;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetStudentListTests : TestBase
{
    [Fact]
    public async Task get_student_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Students.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}