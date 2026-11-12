using Microsoft.AspNetCore.Mvc;

namespace IdentityEmail.Controllers
{
    public class MessageLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
