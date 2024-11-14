using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.CourseDetails;

public class CourseCreatedBy
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Institution))] public string? InstitutionId { get; set; }
    public ICollection<Institution>? Institutions { get; set; }
    [ForeignKey(nameof(Course))] public string? CourseId { get; set; }
    public ICollection<Course>? Courses { get; set; }
}