using IdentityEmail.Context;
using Microsoft.AspNetCore.Mvc;

namespace IdentityEmail.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;

        public MessageController(EmailContext context)
        {
            _context = context;
        }

        public IActionResult Inbox()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }
        public IActionResult Sendbox()
        {
            return View();
        }
        public IActionResult CreateMessage()
        {
            return View();
        }
    }
}
