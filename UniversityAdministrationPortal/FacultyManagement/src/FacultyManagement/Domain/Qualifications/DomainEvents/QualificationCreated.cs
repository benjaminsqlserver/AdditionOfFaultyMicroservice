namespace FacultyManagement.Domain.Qualifications.DomainEvents;

public sealed class QualificationCreated : DomainEvent
{
    public Qualification Qualification { get; set; } 
}
            