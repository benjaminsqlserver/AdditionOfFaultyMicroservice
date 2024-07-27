namespace CourseManagement.SharedTestHelpers.Fakes.Instructor;

using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Instructors.Models;

public class FakeInstructorBuilder
{
    private InstructorForCreation _creationData = new FakeInstructorForCreation().Generate();

    public FakeInstructorBuilder WithModel(InstructorForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeInstructorBuilder WithFirstName(string firstName)
    {
        _creationData.FirstName = firstName;
        return this;
    }
    
    public FakeInstructorBuilder WithLastName(string lastName)
    {
        _creationData.LastName = lastName;
        return this;
    }
    
    public FakeInstructorBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public Instructor Build()
    {
        var result = Instructor.Create(_creationData);
        return result;
    }
}