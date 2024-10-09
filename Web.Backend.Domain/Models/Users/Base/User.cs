using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.Users.Base;

public abstract class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
