namespace FacultyManagement.UnitTests.Domain.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Domain.Qualifications.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class CreateQualificationTests
{
    private readonly Faker _faker;

    public CreateQualificationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_qualification()
    {
        // Arrange
        var qualificationToCreate = new FakeQualificationForCreation().Generate();
        
        // Act
        var qualification = Qualification.Create(qualificationToCreate);

        // Assert
        qualification.FacultyID.Should().Be(qualificationToCreate.FacultyID);
        qualification.Degree.Should().Be(qualificationToCreate.Degree);
        qualification.Institution.Should().Be(qualificationToCreate.Institution);
        qualification.YearOfCompletion.Should().Be(qualificationToCreate.YearOfCompletion);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var qualificationToCreate = new FakeQualificationForCreation().Generate();
        
        // Act
        var qualification = Qualification.Create(qualificationToCreate);

        // Assert
        qualification.DomainEvents.Count.Should().Be(1);
        qualification.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(QualificationCreated));
    }
}