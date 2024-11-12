using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.CourseDetails;

public class Material
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [ForeignKey(nameof(Chapter))] public string? ChapterId { get; set; }
    public ICollection<Chapter>? Chapters { get; set; }
    public int MaterialNumber { get; set; }
    [ForeignKey(nameof(MaterialType))] public string? MaterialTypeId { get; set; }
    public ICollection<MaterialType>? MaterialTypes { get; set; }
    [Column(TypeName = "TEXT")] public string MaterialLink { get; set; }
    public bool IsMandatory { get; set; }
    public int MaxPoints { get; set; }
}