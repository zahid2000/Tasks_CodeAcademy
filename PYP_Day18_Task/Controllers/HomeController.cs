using Microsoft.AspNetCore.Mvc;
using PYP_Day18_Task.Models;
using Serilog;
using System.Diagnostics;

namespace PYP_Day18_Task.Controllers
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
            _logger.LogError("Home Controller");
            return View();
        }

        public IActionResult Privacy()
        {
           Person person = new Person
           {
               Id = 1,
               FirstName="Zahid",
               Surname="Mamedov"
           };
            //Log.Error("{person}",person);
            _logger.LogError("{@person} id {@Id}", person,person.Id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}