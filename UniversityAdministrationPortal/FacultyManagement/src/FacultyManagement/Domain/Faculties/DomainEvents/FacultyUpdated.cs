namespace FacultyManagement.Domain.Faculties.DomainEvents;

public sealed class FacultyUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            