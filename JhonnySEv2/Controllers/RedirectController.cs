using Microsoft.AspNetCore.Mvc;

namespace JhonnySEv2.Controllers
{
    /// <summary>
    /// Proxy subdomain redirect
    /// </summary>
    public class RedirectController : Controller
    {
        public readonly string _githubUrl = "https://www.github.com/jhonnyli";
        public readonly string _linkedinUrl = "https://www.linkedin.com/in/jhonnyli/";

        public IActionResult Github()
        {
            return Redirect(_githubUrl);
        }

        public IActionResult Linkedin()
        {
            return Redirect(_linkedinUrl);
        }
    }
}
