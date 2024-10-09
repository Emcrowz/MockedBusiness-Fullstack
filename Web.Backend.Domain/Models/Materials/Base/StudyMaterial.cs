using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.Materials.Base;

public abstract class StudyMaterial
{
    [Column(TypeName = "NVARCHAR(50)")]
    public string Id { get; set; }
    [Column(TypeName = "NVARCHAR(250)")]
    public string? CoverURI { get; set; }
    [Column(TypeName = "NVARCHAR(100)")]
    public string Topic { get; set; }
    [Column(TypeName = "NVARCHAR(100)")]
    public string Title { get; set; }
    [Column(TypeName = "NVARCHAR(250)")]
    public string Description { get; set; }
    [Column(TypeName = "NVARCHAR(100)")]
    public string Author { get; set; }
    [Column(TypeName = "DOUBLE(8,2)")]
    public decimal? Price { get; set; }
    public bool? IsAvailable { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public DateOnly RevisionDate { get; set; }
}
