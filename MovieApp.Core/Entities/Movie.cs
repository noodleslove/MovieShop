using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Core.Entities;

public class Movie
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string TmdbUrl { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string ImdbUrl { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Title { get; set; }
    public string OverView { get; set; }
    [Column(TypeName = "nvarchar(512)")]
    public string Tagline { get; set; }
    public int Runtime { get; set; }
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Budget { get; set; }
    [Column(TypeName = "decimal(18, 4)")]
    public uint Revenue { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string BackdropUrl { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string PosterUrl { get; set; }
    [Column(TypeName = "nvarchar(64)")]
    public string OriginalLanguage { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string UpdatedBy { get; set; }
    
    // Navigation properties
    public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    public ICollection<Trailer> Trailers { get; set; } = new List<Trailer>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}