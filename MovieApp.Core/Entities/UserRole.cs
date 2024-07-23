using Microsoft.EntityFrameworkCore;

namespace MovieApp.Core.Entities;

[PrimaryKey(nameof(RoleId), nameof(UserId))]
public class UserRole
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
    
    // Navigation properties
    public Role Role { get; set; }
    public User User { get; set; }
}