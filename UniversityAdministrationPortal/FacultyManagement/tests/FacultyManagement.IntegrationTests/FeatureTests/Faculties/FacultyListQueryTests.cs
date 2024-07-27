namespace FacultyManagement.IntegrationTests.FeatureTests.Faculties;

using FacultyManagement.Domain.Faculties.Dtos;
using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.Domain.Faculties.Features;
using Domain;
using System.Threading.Tasks;

public class FacultyListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_faculty_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var facultyOne = new FakeFacultyBuilder().Build();
        var facultyTwo = new FakeFacultyBuilder().Build();
        var queryParameters = new FacultyParametersDto();

        await testingServiceScope.InsertAsync(facultyOne, facultyTwo);

        // Act
        var query = new GetFacultyList.Query(queryParameters);
        var faculties = await testingServiceScope.SendAsync(query);

        // Assert
        faculties.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}