namespace CourseManagement.Domain.Students;

using System.ComponentModel.DataAnnotations;
using CourseManagement.Domain.Enrollments;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CourseManagement.Exceptions;
using CourseManagement.Domain.Students.Models;
using CourseManagement.Domain.Students.DomainEvents;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Models;


public class Student : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }

    public string MatriculationNumber { get; private set; }

    public Guid GenderId { get; private set; }

    private readonly List<Enrollment> _enrollments = new();
    public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Student Create(StudentForCreation studentForCreation)
    {
        var newStudent = new Student();

        newStudent.FirstName = studentForCreation.FirstName;
        newStudent.LastName = studentForCreation.LastName;
        newStudent.Email = studentForCreation.Email;
        newStudent.PhoneNumber = studentForCreation.PhoneNumber;
        newStudent.MatriculationNumber = studentForCreation.MatriculationNumber;
        newStudent.GenderId = studentForCreation.GenderId;

        newStudent.QueueDomainEvent(new StudentCreated(){ Student = newStudent });
        
        return newStudent;
    }

    public Student Update(StudentForUpdate studentForUpdate)
    {
        FirstName = studentForUpdate.FirstName;
        LastName = studentForUpdate.LastName;
        Email = studentForUpdate.Email;
        PhoneNumber = studentForUpdate.PhoneNumber;
        MatriculationNumber = studentForUpdate.MatriculationNumber;
        GenderId = studentForUpdate.GenderId;

        QueueDomainEvent(new StudentUpdated(){ Id = Id });
        return this;
    }

    public Student AddEnrollment(Enrollment enrollment)
    {
        _enrollments.Add(enrollment);
        return this;
    }
    
    public Student RemoveEnrollment(Enrollment enrollment)
    {
        _enrollments.RemoveAll(x => x.Id == enrollment.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Student() { } // For EF + Mocking
}
