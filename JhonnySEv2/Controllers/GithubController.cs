using Microsoft.AspNetCore.Mvc;

namespace JhonnySEv2.Controllers
{
    /// <summary>
    /// Proxy subdomain redirect
    /// </summary>
    public class GithubController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("https://www.github.com/jhonnyli");
        }
    }
}
