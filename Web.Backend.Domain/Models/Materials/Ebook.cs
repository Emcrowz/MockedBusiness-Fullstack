using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.Materials.Base;

public class Ebook : StudyMaterial
{
    [Column(TypeName = "NVARCHAR(15)")]
    public string Isbn { get; set; }
    [Column(TypeName = "NVARCHAR(100)")]
    public string AsociatedTags { get; set; }
    public int PageCount { get; set; }
}
