using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.StudentParticipation;

public class CourseSession
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Course))] public string? CourseId { get; set; }
    public ICollection<Course>? Courses { get; set; }
    [Column(TypeName = "DATE")] public DateOnly StartDate { get; set; }
    [Column(TypeName = "DATE")] public DateOnly EndDate { get; set; }
    [ForeignKey(nameof(SpecializationSession))] public string? SpecializationSessionId { get; set; }
    public ICollection<SpecializationSession>? SpecializationSessions { get; set; }
}