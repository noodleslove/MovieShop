namespace MovieApp.Core.Models.Request;

public class MovieRequestModel
{
    public string TmdbUrl { get; set; }
    public string ImdbUrl { get; set; }
    public string Title { get; set; }
    public string OverView { get; set; }
    public string Tagline { get; set; }
    public int Runtime { get; set; }
    public decimal Budget { get; set; }
    public uint Revenue { get; set; }
    public string BackdropUrl { get; set; }
    public string PosterUrl { get; set; }
    public string OriginalLanguage { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string UpdatedBy { get; set; }
}