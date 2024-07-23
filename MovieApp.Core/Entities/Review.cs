using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Core.Entities;

[PrimaryKey(nameof(MovieId), nameof(UserId))]
public class Review
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    [Column(TypeName = "decimal(3, 2)")]
    public decimal Rating { get; set; }
    [Required]
    public string ReviewText { get; set; }
    
    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public User User { get; set; } = null!;
}