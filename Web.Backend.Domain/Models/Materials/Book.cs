using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.Materials.Base;

public class Book : StudyMaterial
{
    [Column(TypeName = "NVARCHAR(15)")]
    public string Isbn { get; set; }
    [Column(TypeName = "NVARCHAR(100)")]
    public string AsociatedTags { get; set; }
    public int PageCount { get; set; }
    public int Stock { get; set; }
}
