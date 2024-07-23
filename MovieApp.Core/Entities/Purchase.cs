using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Core.Entities;

[PrimaryKey(nameof(MovieId), nameof(UserId))]
public class Purchase
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    [Required]
    public DateTime PurchaseDate { get; set; }
    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid PurchaseNumber { get; set; }
    [Required]
    [Column(TypeName = "decimal(5, 2)")]
    public decimal TotalPrice { get; set; }
    
    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public User User { get; set; } = null!;
}