using Microsoft.AspNetCore.Mvc;

namespace OrderManager.Components
{
    public class BuildingFilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
