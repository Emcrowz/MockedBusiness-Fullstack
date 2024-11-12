using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.SpecializationDetails;

public class SpecializationCreatedBy
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Institution))] public string? InstitutionId { get; set; }
    public ICollection<Institution>? Institutions { get; set; }
    [ForeignKey(nameof(Specialization))] public string? SpecializationId { get; set; }
    public ICollection<Specialization>? Specializations { get; set; }
}