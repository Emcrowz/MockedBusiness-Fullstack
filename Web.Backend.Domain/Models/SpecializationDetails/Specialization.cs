using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.SpecializationDetails;

public class Specialization
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [Column(TypeName = "VARCHAR(255)")] public string Name { get; set; }
    [Column(TypeName = "TEXT")] public string Description { get; set; }
    [Column(TypeName = "DECIMAL(8, 2)")] public decimal SpecializationDiscount { get; set; }
    public bool IsActive { get; set; }
}