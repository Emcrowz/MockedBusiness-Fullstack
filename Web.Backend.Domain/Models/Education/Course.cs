using Web.Backend.Domain.Models.Users;

namespace Web.Backend.Domain.Models.Education;

public class Course
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly UpdateDate { get; set; }

    public string? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    //public string? StudyMaterialId { get; set; }
    //public ICollection<StudyMaterial>? StudyMaterials { get; set; }
}
