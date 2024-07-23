using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Core.Entities;

public class MovieCast
{
    public int MovieId { get; set; }
    public int CastId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(450)")]
    public string Character { get; set; }

    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public Cast Cast { get; set; } = null!;
}