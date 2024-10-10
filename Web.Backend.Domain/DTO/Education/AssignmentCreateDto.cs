using System.ComponentModel.DataAnnotations;
using Web.Backend.Domain.DTO.Users;

namespace Web.Backend.Domain.DTO.Education;

public record AssignmentCreateDto
{
    [Required, StringLength(50), MinLength(2)]
    public string Title { get; init; }
    [Required, StringLength(250), MinLength(2)]
    public string Description { get; init; }
    [DataType(DataType.DateTime)]
    public DateTime? Start { get; init; }
    [DataType(DataType.DateTime)]
    public DateTime? End { get; init; }
    public StudentReadDto? Student { get; init; }
}
