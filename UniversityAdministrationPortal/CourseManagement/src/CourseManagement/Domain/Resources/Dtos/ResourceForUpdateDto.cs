namespace CourseManagement.Domain.Resources.Dtos;

using Destructurama.Attributed;

public sealed record ResourceForUpdateDto
{
    public string ResourceName { get; set; }
    public string ResourceType { get; set; }
    public int Quantity { get; set; }
    public Guid CourseID { get; set; }
}
