using Microsoft.AspNetCore.Mvc;

namespace JhonnySEv2.Controllers
{
    /// <summary>
    /// Proxy subdomain redirect
    /// </summary>
    public class RedirectController : Controller
    {
        public IActionResult Github()
        {
            return Redirect("https://www.github.com/jhonnyli");
        }

        public IActionResult Linkedin()
        {
            return Redirect("https://www.linkedin.com/in/jhonnyli/");
        }
    }
}
