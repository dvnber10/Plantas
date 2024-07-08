using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Plantas.Models;
using Plantas.Services;

namespace Plantas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TargetService _targetService;
    public HomeController(ILogger<HomeController> logger, TargetService service)
    {
        _logger = logger;
        _targetService = service;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Create()
    {
        return Index();
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
