using data_and_repo_pattern.database;
using food_order_system.Services.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system.Controllers
{
    [ApiController]
    public class MenuController : ControllerBase
    {
        IMenuService _imenu;
        public MenuController(IMenuService imenu)
        {
            this._imenu = imenu;
        }

        [HttpGet("api/menu/getall")]
        public async Task<IActionResult> GetAllMenus()
        {
            var result = await _imenu.GetAllMenus();
            return Ok(result);
        }

        [HttpGet("api/menu/getmenubyid")]
        public async Task<IActionResult> GetMenuByID(int id)
        {
            var result = await _imenu.GetMenuById(id);
            return Ok(result);
        }

        [HttpPost("api/menu/createmenu")]
        public async Task<IActionResult> CreateNewMenu(tbMenu menu)
        {
            var result = await _imenu.CreateNewMenu(menu);
            return Ok(result);
        }
    }
}
