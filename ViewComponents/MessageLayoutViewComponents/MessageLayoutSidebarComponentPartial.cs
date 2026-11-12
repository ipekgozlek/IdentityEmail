using Microsoft.AspNetCore.Mvc;

namespace IdentityEmail.ViewComponents.MessageLayoutViewComponents
{
    public class MessageLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
