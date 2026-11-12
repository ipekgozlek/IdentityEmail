using Microsoft.AspNetCore.Mvc;

namespace IdentityEmail.ViewComponents.MessageLayoutViewComponents
{
    public class MessageLayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
