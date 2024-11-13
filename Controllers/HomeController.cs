using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Plantas.DTO;
using Plantas.Models;
using Plantas.Services;
using ZstdSharp.Unsafe;

namespace Plantas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TargetService _targetService;
    private readonly FamilyService _familyService;
    public HomeController(ILogger<HomeController> logger, TargetService service, FamilyService family)
    {
        _logger = logger;
        _targetService = service;
        _familyService = family;
    }

    public IActionResult Index()
    {
        return View();
    }
    // method for add one family of plants
    [HttpPost]
    public async Task<IActionResult> RegisterFamily([FromForm] Family family)
    {
        if (await _familyService.AddFamily(family) == true)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Error("Hubo un error al insertar la familia");
            return RegisterFamily();
        }
    }
    // method for add one plant
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

    public IActionResult RegisterFamily()
    {
        return View();
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

    public IActionResult ViewTarget(string Id)
    {
        var plant = _targetService.VerPlanta(Id).Result;
        return View(plant);
    }

    // Forms Partial
    public IActionResult FormFamily()
    {
        return PartialView("~/Views/Home/Components/_FormFamily.cshtml"); 
    }
    public IActionResult FormPlants()
    {
        return PartialView("~/Views/Home/Components/_FormPlants.cshtml"); 
    }
    public IActionResult FormPlague()
    {
        return PartialView("~/Views/Home/Components/_FormPlague.cshtml"); 
    }
    public IActionResult FormDisease()
    {
        return PartialView("~/Views/Home/Components/_FormDisease.cshtml"); 
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

