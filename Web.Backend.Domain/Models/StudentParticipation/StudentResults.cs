using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Backend.Domain.Models.CourseDetails;

namespace Web.Backend.Domain.Models.StudentParticipation;

public class StudentResults
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Material))] public string? MaterialId { get; set; }
    public ICollection<Material>? Materials { get; set; } 
    [ForeignKey(nameof(EnrolledCourse))] public string? EnrolledCourseId { get; set; }
    public ICollection<EnrolledCourse>? EnrolledCourses { get; set; }
    public int Attempt { get; set; }
    [Column(TypeName = "TEXT")] public string? AttemptLink { get; set; }
    [Column(TypeName = "TIMESTAMP")] public DateTime Started { get; set; }
    [Column(TypeName = "TIMESTAMP")] public DateTime? Ended { get; set; }
    public int? Score { get; set; }
}