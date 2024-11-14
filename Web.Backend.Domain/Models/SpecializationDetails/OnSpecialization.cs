using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.SpecializationDetails;

public class OnSpecialization
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Lecturer))] public string? LecturerId { get; set; }
    public ICollection<Lecturer>? Lecturers { get; set; }
    [ForeignKey(nameof(Specialization))] public string? SpecializationId { get; set; }
    public ICollection<Specialization>? Specializations { get; set; }
}