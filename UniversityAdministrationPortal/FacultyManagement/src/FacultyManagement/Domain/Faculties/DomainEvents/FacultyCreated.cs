namespace FacultyManagement.Domain.Faculties.DomainEvents;

public sealed class FacultyCreated : DomainEvent
{
    public Faculty Faculty { get; set; } 
}
            