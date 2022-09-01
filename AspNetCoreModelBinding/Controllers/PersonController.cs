using AspNetCoreModelBinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreModelBinding.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet("/person/{id}")]
        public IActionResult GetPersonById([ModelBinder(Name = "id")] Person person)
        {
            return View();
        }
    }
}
