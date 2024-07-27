namespace CourseManagement.FunctionalTests.FunctionalTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetEnrollmentListTests : TestBase
{
    [Fact]
    public async Task get_enrollment_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Enrollments.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}