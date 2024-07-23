using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Presentation.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}