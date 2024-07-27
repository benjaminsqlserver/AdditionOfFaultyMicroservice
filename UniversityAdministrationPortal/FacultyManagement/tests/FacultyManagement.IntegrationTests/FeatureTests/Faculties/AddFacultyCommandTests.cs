namespace FacultyManagement.IntegrationTests.FeatureTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FacultyManagement.Domain.Faculties.Features;

public class AddFacultyCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_faculty_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var facultyOne = new FakeFacultyForCreationDto().Generate();

        // Act
        var command = new AddFaculty.Command(facultyOne);
        var facultyReturned = await testingServiceScope.SendAsync(command);
        var facultyCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Faculties
            .FirstOrDefaultAsync(f => f.Id == facultyReturned.Id));

        // Assert
        facultyReturned.FirstName.Should().Be(facultyOne.FirstName);
        facultyReturned.LastName.Should().Be(facultyOne.LastName);
        facultyReturned.Email.Should().Be(facultyOne.Email);
        facultyReturned.Phone.Should().Be(facultyOne.Phone);
        facultyReturned.DateOfBirth.Should().BeCloseTo(facultyOne.DateOfBirth, 1.Seconds());
        facultyReturned.DateOfJoining.Should().BeCloseTo(facultyOne.DateOfJoining, 1.Seconds());
        facultyReturned.Address.Should().Be(facultyOne.Address);

        facultyCreated.FirstName.Should().Be(facultyOne.FirstName);
        facultyCreated.LastName.Should().Be(facultyOne.LastName);
        facultyCreated.Email.Should().Be(facultyOne.Email);
        facultyCreated.Phone.Should().Be(facultyOne.Phone);
        facultyCreated.DateOfBirth.Should().BeCloseTo(facultyOne.DateOfBirth, 1.Seconds());
        facultyCreated.DateOfJoining.Should().BeCloseTo(facultyOne.DateOfJoining, 1.Seconds());
        facultyCreated.Address.Should().Be(facultyOne.Address);
    }
}