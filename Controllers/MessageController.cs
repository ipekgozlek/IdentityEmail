using IdentityEmail.Context;
using IdentityEmail.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityEmail.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox()
        {
            var value = await _userManager.GetUserAsync(User);
            var messageInboxList = await _context.Messages.Where(x => x.ReceiverEmail == value.Email).OrderByDescending(x => x.SendDate).ToListAsync();
            return View(messageInboxList);
        }
        public async Task<IActionResult> Sendbox()
        {
            var value = await _userManager.GetUserAsync(User);
            var messageList = await _context.Messages.Where(x => x.SenderEmail == value.Email).OrderByDescending(x => x.SendDate).ToListAsync();
            return View(messageList);
        }
        public IActionResult CreateMessage()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateMessage(Message message)
        {
            var values = await _userManager.GetUserAsync(User);

            message.SendDate = DateTime.Now;
            message.SenderEmail = values.Email;
            message.IsRead = false;
            message.CategoryId = 1;

            _context.Messages.Add(message);

           await _context.SaveChangesAsync();
            return RedirectToAction("Sendbox");
        }
    }
}
