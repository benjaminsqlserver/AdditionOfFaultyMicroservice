namespace CourseManagement.FunctionalTests.FunctionalTests.Students;

using CourseManagement.SharedTestHelpers.Fakes.Student;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteStudentTests : TestBase
{
    [Fact]
    public async Task delete_student_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var student = new FakeStudentBuilder().Build();
        await InsertAsync(student);

        // Act
        var route = ApiRoutes.Students.Delete(student.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}