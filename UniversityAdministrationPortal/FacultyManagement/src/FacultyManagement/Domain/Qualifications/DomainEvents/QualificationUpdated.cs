namespace FacultyManagement.Domain.Qualifications.DomainEvents;

public sealed class QualificationUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            