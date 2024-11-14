using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.CourseDetails;

public class OnCourse
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Lecturer))] public string? LecturerId { get; set; }
    public ICollection<Lecturer>? Lecturers { get; set; }
    [ForeignKey(nameof(Course))] public string? CourseId { get; set; }
    public ICollection<Course>? Courses { get; set; }
}