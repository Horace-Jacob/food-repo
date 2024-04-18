using data_and_repo_pattern.helper.MenuApiRequest;
using data_and_repo_pattern.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace food_order_system_web.Controllers
{
    public class SingleController : Controller
    {
        IMenuApiRequest _imenu;
        public SingleController(IMenuApiRequest imenu) 
        { 
            _imenu = imenu;
        }
        public IActionResult Index() { return View(); }
        public async Task<IActionResult> _singlemenus(int id)
        {
            var result = await _imenu.GetMenuById(id);
            var carts = HttpContext.Session.GetString("user_items");
            List<CartViewModel> lcvm = new List<CartViewModel>();
            if(carts == null)
            {
                HttpContext.Session.SetString("user_items", JsonConvert.SerializeObject(lcvm));
            }
            return PartialView("_singlemenus", result);
        }

        public IActionResult AddToCart(int id, string name, int quantity, int subtotal, int price)
        {
            CartViewModel cvm = new CartViewModel
            {
                id = id,
                Name = name,
                Quantity = quantity,
                Subtotal = subtotal,
                Price = price,
            };
            var result = HttpContext.Session.GetString("user_items");
            if(result != null)
            {
                var existingCarts = JsonConvert.DeserializeObject<List<CartViewModel>>(result);
                existingCarts.Add(cvm);
                HttpContext.Session.SetString("user_items", JsonConvert.SerializeObject(existingCarts));
            }
            return Ok("success");
        }
    }
}
