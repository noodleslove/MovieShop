using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Presentation.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}