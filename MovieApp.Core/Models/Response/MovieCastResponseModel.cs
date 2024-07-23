namespace MovieApp.Core.Models.Response;

public class MovieCastResponseModel
{
    public int MovieId { get; set; }
    public int CastId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string TmdbUrl { get; set; }
    public string ProfilePath { get; set; }
    public string Character { get; set; }
}