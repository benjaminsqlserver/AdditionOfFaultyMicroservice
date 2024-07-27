namespace CourseManagement.Domain.Instructors;

using System.ComponentModel.DataAnnotations;
using CourseManagement.Domain.Schedules;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CourseManagement.Exceptions;
using CourseManagement.Domain.Instructors.Models;
using CourseManagement.Domain.Instructors.DomainEvents;
using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.Models;


public class Instructor : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    private readonly List<Schedule> _schedules = new();
    public IReadOnlyCollection<Schedule> Schedules => _schedules.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Instructor Create(InstructorForCreation instructorForCreation)
    {
        var newInstructor = new Instructor();

        newInstructor.FirstName = instructorForCreation.FirstName;
        newInstructor.LastName = instructorForCreation.LastName;
        newInstructor.Email = instructorForCreation.Email;

        newInstructor.QueueDomainEvent(new InstructorCreated(){ Instructor = newInstructor });
        
        return newInstructor;
    }

    public Instructor Update(InstructorForUpdate instructorForUpdate)
    {
        FirstName = instructorForUpdate.FirstName;
        LastName = instructorForUpdate.LastName;
        Email = instructorForUpdate.Email;

        QueueDomainEvent(new InstructorUpdated(){ Id = Id });
        return this;
    }

    public Instructor AddSchedule(Schedule schedule)
    {
        _schedules.Add(schedule);
        return this;
    }
    
    public Instructor RemoveSchedule(Schedule schedule)
    {
        _schedules.RemoveAll(x => x.Id == schedule.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Instructor() { } // For EF + Mocking
}
