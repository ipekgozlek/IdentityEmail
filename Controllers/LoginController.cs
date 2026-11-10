using Microsoft.AspNetCore.Mvc;

namespace IdentityEmail.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
