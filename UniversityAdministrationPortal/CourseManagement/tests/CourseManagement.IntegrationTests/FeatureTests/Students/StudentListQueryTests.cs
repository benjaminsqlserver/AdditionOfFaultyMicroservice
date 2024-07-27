namespace CourseManagement.IntegrationTests.FeatureTests.Students;

using CourseManagement.Domain.Students.Dtos;
using CourseManagement.SharedTestHelpers.Fakes.Student;
using CourseManagement.Domain.Students.Features;
using Domain;
using System.Threading.Tasks;

public class StudentListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_student_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentOne = new FakeStudentBuilder().Build();
        var studentTwo = new FakeStudentBuilder().Build();
        var queryParameters = new StudentParametersDto();

        await testingServiceScope.InsertAsync(studentOne, studentTwo);

        // Act
        var query = new GetStudentList.Query(queryParameters);
        var students = await testingServiceScope.SendAsync(query);

        // Assert
        students.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}