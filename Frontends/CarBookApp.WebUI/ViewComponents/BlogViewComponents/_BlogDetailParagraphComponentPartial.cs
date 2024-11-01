using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailParagraphComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
