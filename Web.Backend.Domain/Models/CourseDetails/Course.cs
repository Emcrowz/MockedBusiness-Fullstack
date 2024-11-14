using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Backend.Domain.Models.SpecializationDetails;

namespace Web.Backend.Domain.Models;

public class Course
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [Column(TypeName = "VARCHAR(255)")] public string Name { get; set; }
    [Column(TypeName = "VARCHAR(255)")] public string Commitment { get; set; }
    [Column(TypeName = "TEXT")] public string Description { get; set; }
    [Column(TypeName = "DECIMAL(5, 2)")] public decimal MinGrade { get; set; }
    [Column(TypeName = "DECIMAL(8, 2)")] public decimal Price { get; set; }
    public bool IsActive { get; set; }
    [ForeignKey(nameof(Specialization))] public string? SpecializationId { get; set; }
    public ICollection<Specialization>? Specializations { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly UpdateDate { get; set; }
}
