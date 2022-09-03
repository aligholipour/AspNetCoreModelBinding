using AspNetCoreModelBinding.ModelBindings.CountriesModelBindings;
using AspNetCoreModelBinding.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace AspNetCoreModelBinding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Countries pattern => {iran,denmark,Switzerland}

        [HttpGet("Countries/{countries}")]
        public IActionResult Countries([ModelBinder(typeof(CountryModelBinding))] string[] countries)
        {
            return Ok(countries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}