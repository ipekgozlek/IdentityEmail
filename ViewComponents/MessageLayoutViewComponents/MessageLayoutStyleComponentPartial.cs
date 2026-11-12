using Microsoft.AspNetCore.Mvc;

namespace IdentityEmail.ViewComponents.MessageLayoutViewComponents
{
    public class MessageLayoutStyleComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
