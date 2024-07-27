namespace FacultyManagement.Domain.Faculties;

using System.ComponentModel.DataAnnotations;
using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Qualifications;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using FacultyManagement.Exceptions;
using FacultyManagement.Domain.Faculties.Models;
using FacultyManagement.Domain.Faculties.DomainEvents;
using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Domain.Qualifications.Models;
using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Schedules.Models;
using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.Models;


public class Faculty : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Phone { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public DateTime DateOfJoining { get; private set; }

    public string Address { get; private set; }

    private readonly List<Qualification> _qualifications = new();
    public IReadOnlyCollection<Qualification> Qualifications => _qualifications.AsReadOnly();

    private readonly List<Schedule> _schedules = new();
    public IReadOnlyCollection<Schedule> Schedules => _schedules.AsReadOnly();

    private readonly List<Evaluation> _evaluations = new();
    public IReadOnlyCollection<Evaluation> Evaluations => _evaluations.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Faculty Create(FacultyForCreation facultyForCreation)
    {
        var newFaculty = new Faculty();

        newFaculty.FirstName = facultyForCreation.FirstName;
        newFaculty.LastName = facultyForCreation.LastName;
        newFaculty.Email = facultyForCreation.Email;
        newFaculty.Phone = facultyForCreation.Phone;
        newFaculty.DateOfBirth = facultyForCreation.DateOfBirth;
        newFaculty.DateOfJoining = facultyForCreation.DateOfJoining;
        newFaculty.Address = facultyForCreation.Address;

        newFaculty.QueueDomainEvent(new FacultyCreated(){ Faculty = newFaculty });
        
        return newFaculty;
    }

    public Faculty Update(FacultyForUpdate facultyForUpdate)
    {
        FirstName = facultyForUpdate.FirstName;
        LastName = facultyForUpdate.LastName;
        Email = facultyForUpdate.Email;
        Phone = facultyForUpdate.Phone;
        DateOfBirth = facultyForUpdate.DateOfBirth;
        DateOfJoining = facultyForUpdate.DateOfJoining;
        Address = facultyForUpdate.Address;

        QueueDomainEvent(new FacultyUpdated(){ Id = Id });
        return this;
    }

    public Faculty AddQualification(Qualification qualification)
    {
        _qualifications.Add(qualification);
        return this;
    }
    
    public Faculty RemoveQualification(Qualification qualification)
    {
        _qualifications.RemoveAll(x => x.Id == qualification.Id);
        return this;
    }

    public Faculty AddSchedule(Schedule schedule)
    {
        _schedules.Add(schedule);
        return this;
    }
    
    public Faculty RemoveSchedule(Schedule schedule)
    {
        _schedules.RemoveAll(x => x.Id == schedule.Id);
        return this;
    }

    public Faculty AddEvaluation(Evaluation evaluation)
    {
        _evaluations.Add(evaluation);
        return this;
    }
    
    public Faculty RemoveEvaluation(Evaluation evaluation)
    {
        _evaluations.RemoveAll(x => x.Id == evaluation.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Faculty() { } // For EF + Mocking
}
