using Web.Backend.Domain.DTO.Users;

namespace Web.Backend.Domain.DTO.Education;

public record AssignmentReadDto
{
    public string Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public DateTime? Start { get; init; }
    public DateTime? End { get; init; }
    public StudentReadDto? Student { get; init; }
}
