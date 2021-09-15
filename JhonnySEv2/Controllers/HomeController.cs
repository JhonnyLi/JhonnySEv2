using JhonnySEv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace JhonnySEv2.Controllers
{
    [ResponseCache(CacheProfileName = "default")]
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

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            var rng = new Random();
            var model = new ErrorModel
            {
                StatusCode = code,
                Title = "Page not found",
                Message = $"Take this instead",
                Url = $"https://placekitten.com/{rng.Next(300,600)}/{rng.Next(300,600)}"
            };

            return View("~/Views/Shared/HandleError.cshtml", model);
        }
    }
}
