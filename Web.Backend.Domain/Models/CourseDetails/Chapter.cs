using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.CourseDetails;

public class Chapter
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Course))] public string? CourseId { get; set; }
    public ICollection<Course>? Courses { get; set; }
    public int Number { get; set; }
    [Column(TypeName = "TEXT")] public string Description { get; set; }
}