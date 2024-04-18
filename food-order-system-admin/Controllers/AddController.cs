using data_and_repo_pattern.database;
using data_and_repo_pattern.helper.MenuApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_admin.Controllers
{
    public class AddController : Controller
    {
        IMenuApiRequest _imenu;
        public AddController(IMenuApiRequest imenu) 
        { 
            _imenu = imenu;
        }
        public ActionResult Index() 
        { 
            return View(); 
        }
        public async Task<IActionResult> CreateMenu(tbMenu menu)
        {
            var result = await _imenu.CreateNewMenu(menu);
            return Ok(result);
        }

    }
}
