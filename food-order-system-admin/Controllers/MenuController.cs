using data_and_repo_pattern.helper.MenuApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_admin.Controllers
{
    public class MenuController : Controller
    {
        IMenuApiRequest _imenu;
        public MenuController(IMenuApiRequest imenu) 
        { 
            _imenu = imenu;
        }
        public IActionResult Index() 
        { 
            return View(); 
        }

        

        public async Task<IActionResult> _allmenu()
        {
            var result = await _imenu.GetAllMenus();
            return PartialView("_allmenu", result);
        }
    }
}
