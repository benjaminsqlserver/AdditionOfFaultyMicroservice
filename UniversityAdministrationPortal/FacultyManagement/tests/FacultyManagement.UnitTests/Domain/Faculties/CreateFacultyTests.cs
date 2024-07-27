namespace FacultyManagement.UnitTests.Domain.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.Domain.Faculties;
using FacultyManagement.Domain.Faculties.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class CreateFacultyTests
{
    private readonly Faker _faker;

    public CreateFacultyTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_faculty()
    {
        // Arrange
        var facultyToCreate = new FakeFacultyForCreation().Generate();
        
        // Act
        var faculty = Faculty.Create(facultyToCreate);

        // Assert
        faculty.FirstName.Should().Be(facultyToCreate.FirstName);
        faculty.LastName.Should().Be(facultyToCreate.LastName);
        faculty.Email.Should().Be(facultyToCreate.Email);
        faculty.Phone.Should().Be(facultyToCreate.Phone);
        faculty.DateOfBirth.Should().BeCloseTo(facultyToCreate.DateOfBirth, 1.Seconds());
        faculty.DateOfJoining.Should().BeCloseTo(facultyToCreate.DateOfJoining, 1.Seconds());
        faculty.Address.Should().Be(facultyToCreate.Address);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var facultyToCreate = new FakeFacultyForCreation().Generate();
        
        // Act
        var faculty = Faculty.Create(facultyToCreate);

        // Assert
        faculty.DomainEvents.Count.Should().Be(1);
        faculty.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(FacultyCreated));
    }
}