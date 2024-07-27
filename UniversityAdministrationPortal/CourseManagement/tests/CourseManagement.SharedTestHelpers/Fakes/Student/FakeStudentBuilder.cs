namespace CourseManagement.SharedTestHelpers.Fakes.Student;

using CourseManagement.Domain.Students;
using CourseManagement.Domain.Students.Models;

public class FakeStudentBuilder
{
    private StudentForCreation _creationData = new FakeStudentForCreation().Generate();

    public FakeStudentBuilder WithModel(StudentForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeStudentBuilder WithFirstName(string firstName)
    {
        _creationData.FirstName = firstName;
        return this;
    }
    
    public FakeStudentBuilder WithLastName(string lastName)
    {
        _creationData.LastName = lastName;
        return this;
    }
    
    public FakeStudentBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public FakeStudentBuilder WithPhoneNumber(string phoneNumber)
    {
        _creationData.PhoneNumber = phoneNumber;
        return this;
    }
    
    public FakeStudentBuilder WithMatriculationNumber(string matriculationNumber)
    {
        _creationData.MatriculationNumber = matriculationNumber;
        return this;
    }
    
    public FakeStudentBuilder WithGenderId(Guid genderId)
    {
        _creationData.GenderId = genderId;
        return this;
    }
    
    public Student Build()
    {
        var result = Student.Create(_creationData);
        return result;
    }
}