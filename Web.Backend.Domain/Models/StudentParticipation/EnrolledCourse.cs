using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.StudentParticipation;

public class EnrolledCourse
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Student))] public string? StudentId { get; set; }
    public ICollection<Student>? Students { get; set; }
    [ForeignKey(nameof(CourseSession))] public string? CourseSessionId { get; set; }
    public ICollection<CourseSession>? CourseSessions { get; set; }
    [Column(TypeName = "DATE")] public DateTime EnrollmentDate { get; set; }
    public string? StatusId { get; set; }
    public ICollection<Status>? Status { get; set; }
    [Column(TypeName = "DATE")] public DateOnly? StatusDate { get; set; }
    [Column(TypeName = "DECIMAL(5, 2)")] public decimal? FinalGrade { get; set; }
    [Column(TypeName = "TEXT")] public string? CertificateId { get; set; }
    [Column(TypeName = "TEXT")] public string? CertificateLocation { get; set; }
}