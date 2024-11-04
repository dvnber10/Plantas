using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plantas.DTO;
using Plantas.Services;

namespace Plantas.Controllers
{
    [Route("[controller]")]
    public class Actions : Controller
    {
        private readonly TargetService _targetService;
        private readonly ILogger<Actions> _logger;

        public Actions(ILogger<Actions> logger, TargetService target)
        {
            _logger = logger;
            _targetService = target;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ViewTarget(string Id)
        {
            var plant = _targetService.VerPlanta(Id).Result;
            return View(plant);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}