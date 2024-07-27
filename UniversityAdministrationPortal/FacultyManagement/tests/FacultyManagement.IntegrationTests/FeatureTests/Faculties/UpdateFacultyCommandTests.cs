namespace FacultyManagement.IntegrationTests.FeatureTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.Domain.Faculties.Dtos;
using FacultyManagement.Domain.Faculties.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateFacultyCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_faculty_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var faculty = new FakeFacultyBuilder().Build();
        await testingServiceScope.InsertAsync(faculty);
        var updatedFacultyDto = new FakeFacultyForUpdateDto().Generate();

        // Act
        var command = new UpdateFaculty.Command(faculty.Id, updatedFacultyDto);
        await testingServiceScope.SendAsync(command);
        var updatedFaculty = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Faculties
                .FirstOrDefaultAsync(f => f.Id == faculty.Id));

        // Assert
        updatedFaculty.FirstName.Should().Be(updatedFacultyDto.FirstName);
        updatedFaculty.LastName.Should().Be(updatedFacultyDto.LastName);
        updatedFaculty.Email.Should().Be(updatedFacultyDto.Email);
        updatedFaculty.Phone.Should().Be(updatedFacultyDto.Phone);
        updatedFaculty.DateOfBirth.Should().BeCloseTo(updatedFacultyDto.DateOfBirth, 1.Seconds());
        updatedFaculty.DateOfJoining.Should().BeCloseTo(updatedFacultyDto.DateOfJoining, 1.Seconds());
        updatedFaculty.Address.Should().Be(updatedFacultyDto.Address);
    }
}