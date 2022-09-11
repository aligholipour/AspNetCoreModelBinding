using AspNetCoreModelBinding.ModelBindings.CountriesModelBindings;
using AspNetCoreModelBinding.ModelBindings.ExchangeCurrency;
using AspNetCoreModelBinding.Models;
using AspNetCoreModelBinding.Models.ExchangeCurrency;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        //Countries pattern => {iran,denmark,Switzerland}
        //Example: /CountriesModelBinderAttribute/iran,denmark,Switzerland
        [HttpGet("CountriesModelBinderAttribute/{countries}")]
        public IActionResult CountriesWithModelBinderAttribute([ModelBinder(typeof(CountryModelBinding))] Country countries)
        {
            return Ok(countries);
        }

        //Countries pattern => {iran,denmark,Switzerland}
        //Example: /CountriesBinderProvider/iran,denmark,Switzerland
        [HttpGet("CountriesBinderProvider/{countries}")]
        public IActionResult CountriesWithBinderProvider(Country countries)
        {
            return Ok(countries);
        }

        //Currency pattern => {amount}-from}-{to}
        //Example: /ExchangeCurrency/100-USD-CHF
        [HttpGet("ExchangeCurrency/{currency}")]
        public IActionResult ExchangeCurrency([ModelBinder(typeof(ExchangeCurrency))] CurrencyModel currency)
        {
            return Ok(currency);
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
}