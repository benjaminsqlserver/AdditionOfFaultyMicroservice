namespace FacultyManagement.UnitTests.Domain.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.Domain.Faculties;
using FacultyManagement.Domain.Faculties.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class UpdateFacultyTests
{
    private readonly Faker _faker;

    public UpdateFacultyTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_faculty()
    {
        // Arrange
        var faculty = new FakeFacultyBuilder().Build();
        var updatedFaculty = new FakeFacultyForUpdate().Generate();
        
        // Act
        faculty.Update(updatedFaculty);

        // Assert
        faculty.FirstName.Should().Be(updatedFaculty.FirstName);
        faculty.LastName.Should().Be(updatedFaculty.LastName);
        faculty.Email.Should().Be(updatedFaculty.Email);
        faculty.Phone.Should().Be(updatedFaculty.Phone);
        faculty.DateOfBirth.Should().BeCloseTo(updatedFaculty.DateOfBirth, 1.Seconds());
        faculty.DateOfJoining.Should().BeCloseTo(updatedFaculty.DateOfJoining, 1.Seconds());
        faculty.Address.Should().Be(updatedFaculty.Address);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var faculty = new FakeFacultyBuilder().Build();
        var updatedFaculty = new FakeFacultyForUpdate().Generate();
        faculty.DomainEvents.Clear();
        
        // Act
        faculty.Update(updatedFaculty);

        // Assert
        faculty.DomainEvents.Count.Should().Be(1);
        faculty.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(FacultyUpdated));
    }
}