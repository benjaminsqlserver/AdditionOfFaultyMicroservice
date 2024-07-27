namespace FacultyManagement.SharedTestHelpers.Fakes.Faculty;

using FacultyManagement.Domain.Faculties;
using FacultyManagement.Domain.Faculties.Models;

public class FakeFacultyBuilder
{
    private FacultyForCreation _creationData = new FakeFacultyForCreation().Generate();

    public FakeFacultyBuilder WithModel(FacultyForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeFacultyBuilder WithFirstName(string firstName)
    {
        _creationData.FirstName = firstName;
        return this;
    }
    
    public FakeFacultyBuilder WithLastName(string lastName)
    {
        _creationData.LastName = lastName;
        return this;
    }
    
    public FakeFacultyBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public FakeFacultyBuilder WithPhone(string phone)
    {
        _creationData.Phone = phone;
        return this;
    }
    
    public FakeFacultyBuilder WithDateOfBirth(DateTime dateOfBirth)
    {
        _creationData.DateOfBirth = dateOfBirth;
        return this;
    }
    
    public FakeFacultyBuilder WithDateOfJoining(DateTime dateOfJoining)
    {
        _creationData.DateOfJoining = dateOfJoining;
        return this;
    }
    
    public FakeFacultyBuilder WithAddress(string address)
    {
        _creationData.Address = address;
        return this;
    }
    
    public Faculty Build()
    {
        var result = Faculty.Create(_creationData);
        return result;
    }
}