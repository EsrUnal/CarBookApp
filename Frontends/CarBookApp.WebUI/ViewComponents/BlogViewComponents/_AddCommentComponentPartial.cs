using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _AddCommentComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
