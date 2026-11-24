using IdentityEmail.Entities;
using IdentityEmail.Models;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Utils;

namespace IdentityEmail.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel userRegisterViewModel)
        {
            Random random = new Random();
            int validationCode =random.Next(100000, 1000000);

            AppUser appUser = new AppUser()
            {
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                Email = userRegisterViewModel.Email,
                UserName = userRegisterViewModel.Username,
                ValidCode = validationCode

            };
            var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);

            if (result.Succeeded)
            {
              
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("Identity Postane", "email");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress(userRegisterViewModel.Name + " " + userRegisterViewModel.Surname, userRegisterViewModel.Email);
                mimeMessage.To.Add(mailboxAddressTo);

                mimeMessage.Subject = "Doğrulama Kodu";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Doğrulama Kodunuz: " + validationCode;
                mimeMessage.Body = bodyBuilder.ToMessageBody();


                SmtpClient smtpClient = new SmtpClient();// SmtpClient .net li olmayanı seç mailkit

                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("ipekgg89@gmail.com", "xfbj lbbb opod wemi");
                smtpClient.Send(mimeMessage); // smtpClient SEND  satırını sil bi daha yaz send için .net li olmayanı seç

                smtpClient.Disconnect(true);
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
