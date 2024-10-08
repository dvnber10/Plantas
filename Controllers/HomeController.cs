using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Plantas.DTO;
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
    [HttpPost]
    public async Task<IActionResult> Register([FromForm] PlantDTO plant)
    {
        
        if (await _targetService.InsertarPlanta(plant) == true)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Error("Hubo un error al insertar la planta");
            return Register();
        }

    }

    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Dashboard()
    {
        var plants = _targetService.GetPlants().Result;
        return View(plants);
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
