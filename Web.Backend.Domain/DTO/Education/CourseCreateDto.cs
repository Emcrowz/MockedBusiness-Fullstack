using System.ComponentModel.DataAnnotations;
using Web.Backend.Domain.DTO.Users;

namespace Web.Backend.Domain.DTO.Education;

public record CourseCreateDto
{
    [Required, MaxLength(50), MinLength(2)]
    public string? Title { get; init; }
    [Required, MaxLength(250), MinLength(2)]
    public string? Description { get; init; }
    [DataType(DataType.Currency), Range(0, int.MaxValue)]
    public decimal? Price { get; init; }
    [DataType(DataType.Date)]
    public DateOnly ReleaseDate { get; init; }
    public DateOnly UpdateDate { get; init; }
    public TeacherReadDto? Teacher { get; init; }
}
