namespace FacultyManagement.UnitTests.Domain.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Domain.Qualifications.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class UpdateQualificationTests
{
    private readonly Faker _faker;

    public UpdateQualificationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_qualification()
    {
        // Arrange
        var qualification = new FakeQualificationBuilder().Build();
        var updatedQualification = new FakeQualificationForUpdate().Generate();
        
        // Act
        qualification.Update(updatedQualification);

        // Assert
        qualification.FacultyID.Should().Be(updatedQualification.FacultyID);
        qualification.Degree.Should().Be(updatedQualification.Degree);
        qualification.Institution.Should().Be(updatedQualification.Institution);
        qualification.YearOfCompletion.Should().Be(updatedQualification.YearOfCompletion);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var qualification = new FakeQualificationBuilder().Build();
        var updatedQualification = new FakeQualificationForUpdate().Generate();
        qualification.DomainEvents.Clear();
        
        // Act
        qualification.Update(updatedQualification);

        // Assert
        qualification.DomainEvents.Count.Should().Be(1);
        qualification.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(QualificationUpdated));
    }
}