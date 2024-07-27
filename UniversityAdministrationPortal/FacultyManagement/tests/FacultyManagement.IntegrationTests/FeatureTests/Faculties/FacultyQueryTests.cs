namespace FacultyManagement.IntegrationTests.FeatureTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.Domain.Faculties.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class FacultyQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_faculty_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var facultyOne = new FakeFacultyBuilder().Build();
        await testingServiceScope.InsertAsync(facultyOne);

        // Act
        var query = new GetFaculty.Query(facultyOne.Id);
        var faculty = await testingServiceScope.SendAsync(query);

        // Assert
        faculty.FirstName.Should().Be(facultyOne.FirstName);
        faculty.LastName.Should().Be(facultyOne.LastName);
        faculty.Email.Should().Be(facultyOne.Email);
        faculty.Phone.Should().Be(facultyOne.Phone);
        faculty.DateOfBirth.Should().BeCloseTo(facultyOne.DateOfBirth, 1.Seconds());
        faculty.DateOfJoining.Should().BeCloseTo(facultyOne.DateOfJoining, 1.Seconds());
        faculty.Address.Should().Be(facultyOne.Address);
    }

    [Fact]
    public async Task get_faculty_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetFaculty.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}