using Microsoft.AspNetCore.Mvc;

namespace IdentityEmail.ViewComponents.MessageLayoutViewComponents
{
    public class MessageLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
