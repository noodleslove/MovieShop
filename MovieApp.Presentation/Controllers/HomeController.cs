using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Interfaces.Service;
using MovieApp.Core.Models.Response;
using MovieApp.Presentation.Models;

namespace MovieApp.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieService _movieService;

    public HomeController(ILogger<HomeController> logger, IMovieService movieService)
    {
        _logger = logger;
        _movieService = movieService;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetHighestGrossingMovies();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}