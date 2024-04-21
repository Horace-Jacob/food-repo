using data_and_repo_pattern.database;
using data_and_repo_pattern.helper.MenuApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_admin.Controllers
{
    public class EditController : Controller
    {
        IMenuApiRequest _imenu;
        public EditController(IMenuApiRequest imenu) { _imenu = imenu; }
        public IActionResult Index() { return View(); }
        public async Task<IActionResult> EditMenu(tbMenu menu)
        {
            var result = await _imenu.CreateNewMenu(menu);
            return Ok(result);
        }
        public async Task<IActionResult> _editdata(int id)
        {
            var result = await _imenu.GetMenuById(id);
            return PartialView("_editdata", result);
        }

        public async Task<IActionResult> UpdateMenu(tbMenu menu)
        {
            var result = await _imenu.CreateNewMenu(menu);
            return Ok(result);
        }
    }
}
