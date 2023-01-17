using Microsoft.AspNetCore.Mvc;

namespace C1Copy.Controllers;

public class DatabaseController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public DatabaseController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
}