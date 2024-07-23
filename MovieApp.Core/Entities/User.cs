using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Core.Entities;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string HashedPassword { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string LastName { get; set; }
    [Column(TypeName = "nvarchar(16)")]
    public string? PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(1024)")]
    public string Salt { get; set; }
    public bool IsLocked { get; set; }
    
    // Navigation properties
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}