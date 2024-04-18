using data_and_repo_pattern.helper.MenuApiRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace food_order_system_web.Controllers
{
    public class MenuController : Controller
    {
        IMenuApiRequest _imenu;
        public MenuController(IMenuApiRequest imenu) 
        { 
            _imenu = imenu;
        }
        public ActionResult Index() { return View(); }

        public async Task<IActionResult> _allmenus()
        {
            var result = await _imenu.GetAllMenus();
            return PartialView("_allmenus", result);
        }
    }
}
