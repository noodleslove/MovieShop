using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Core.Entities;

public class Role
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string Name { get; set; }
    
    // Navigation properties
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}