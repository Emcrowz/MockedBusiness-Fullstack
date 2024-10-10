using System.ComponentModel.DataAnnotations;
using Web.Backend.Domain.DTO.Users;

namespace Web.Backend.Domain.DTO.Education;

public record CourseReadDto
{
    public string Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public decimal? Price { get; init; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateOnly ReleaseDate { get; init; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateOnly UpdateDate { get; init; }
    public TeacherReadDto? Teacher { get; init; }
    //public StudentReadDto? Student { get; init; }
    //public TeacherReadDto? Teacher { get; init; }
    //public List<AssignmentReadDto>? Assignments { get; init; }
}
