namespace FacultyManagement.Domain.Qualifications.Dtos;

using Destructurama.Attributed;

public sealed record QualificationForCreationDto
{
    public Guid FacultyID { get; set; }
    public string Degree { get; set; }
    public string Institution { get; set; }
    public int YearOfCompletion { get; set; }
}
