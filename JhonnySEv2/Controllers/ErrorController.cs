using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JhonnySEv2.Controllers
{
    [ResponseCache(CacheProfileName = "default")]
    public class ErrorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ErrorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? statusCode = null)
        {
            if (statusCode == null || statusCode == 200 || statusCode == 404)
            {
                return RedirectToAction("Index", "Home");
            }

             _logger.LogError($"Error occurred with status code: {statusCode}");

            ViewData["StatusCode"] = statusCode;
            return View();
        }
    }
}
