using IdentityEmail.Entities;
using IdentityEmail.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityEmail.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginViewModel userLoginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userLoginViewModel.Username,
                userLoginViewModel.Password,
                false,
                false);

            if (result.Succeeded)
            {
                return RedirectToAction("Inbox", "Message");
            }

            return View();
        }
    }
}