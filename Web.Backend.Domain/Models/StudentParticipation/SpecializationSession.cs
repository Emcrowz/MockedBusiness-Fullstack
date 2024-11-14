using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Backend.Domain.Models.SpecializationDetails;

namespace Web.Backend.Domain.Models.StudentParticipation;

public class SpecializationSession
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Specialization))] public string? SpecializationId { get; set; }
    public ICollection<Specialization>? Specializations { get; set; }
    [Column(TypeName = "DATE")] public DateOnly StartDate { get; set; }
    [Column(TypeName = "DATE")] public DateOnly EndDate { get; set; }
}