namespace FacultyManagement.Domain.Qualifications;

using System.ComponentModel.DataAnnotations;
using FacultyManagement.Domain.Faculties;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using FacultyManagement.Exceptions;
using FacultyManagement.Domain.Qualifications.Models;
using FacultyManagement.Domain.Qualifications.DomainEvents;


public class Qualification : BaseEntity
{
    public Guid FacultyID { get; private set; }

    public string Degree { get; private set; }

    public string Institution { get; private set; }

    public int YearOfCompletion { get; private set; }

    public Faculty Faculty { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Qualification Create(QualificationForCreation qualificationForCreation)
    {
        var newQualification = new Qualification();

        newQualification.FacultyID = qualificationForCreation.FacultyID;
        newQualification.Degree = qualificationForCreation.Degree;
        newQualification.Institution = qualificationForCreation.Institution;
        newQualification.YearOfCompletion = qualificationForCreation.YearOfCompletion;

        newQualification.QueueDomainEvent(new QualificationCreated(){ Qualification = newQualification });
        
        return newQualification;
    }

    public Qualification Update(QualificationForUpdate qualificationForUpdate)
    {
        FacultyID = qualificationForUpdate.FacultyID;
        Degree = qualificationForUpdate.Degree;
        Institution = qualificationForUpdate.Institution;
        YearOfCompletion = qualificationForUpdate.YearOfCompletion;

        QueueDomainEvent(new QualificationUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Qualification() { } // For EF + Mocking
}
