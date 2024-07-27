namespace FacultyManagement.Domain.Faculties.Dtos;

using Destructurama.Attributed;

public sealed record FacultyDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfJoining { get; set; }
    public string Address { get; set; }

}
