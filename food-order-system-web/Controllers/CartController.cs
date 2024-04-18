using data_and_repo_pattern.database;
using data_and_repo_pattern.helper.MenuApiRequest;
using data_and_repo_pattern.helper.OrderApiRequest;
using data_and_repo_pattern.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace food_order_system_web.Controllers
{
    public class CartController : Controller
    {
        IMenuApiRequest _imenu;
        IOrderApiRequest _iorder;

        public CartController(IMenuApiRequest imenu, IOrderApiRequest iorder) 
        { 
            _imenu = imenu;
            _iorder = iorder;
        }
        public IActionResult Index() { return View(); }
        public IActionResult GetAllCartItems()
        {
            var result = HttpContext.Session.GetString("user_items");

            if(result != null)
            {
                var existingItems = JsonConvert.DeserializeObject<List<CartViewModel>>(result);
                return Ok(existingItems);
            }
            return Ok();
        }

        public IActionResult _cartitems()
        {
            var result = HttpContext.Session.GetString("user_items");
            List<CartViewModel> newList = new List<CartViewModel>();
            if (result != null)
            {
                var existingItems = JsonConvert.DeserializeObject<List<CartViewModel>>(result);
                return PartialView("_cartitems", existingItems);
            }
            return PartialView("_cartitems", newList);
        }

        public IActionResult RemoveItem(int id)
        {
            var result = HttpContext.Session.GetString("user_items");
            if (result != null)
            {
                var existingItems = JsonConvert.DeserializeObject<List<CartViewModel>>(result);

                // Find the item with the given ID
                var itemToRemove = existingItems.FirstOrDefault(item => item.id == id);
                if (itemToRemove != null)
                {
                    // Remove the item from the list
                    existingItems.Remove(itemToRemove);

                    // Serialize the updated list and store it back into the session
                    HttpContext.Session.SetString("user_items", JsonConvert.SerializeObject(existingItems));
                }
            }
            return RedirectToAction("Index", "Cart"); // Redirect to the cart page after removing the item
        }

        public async Task<IActionResult> Checkout(string address, int phonenumber, int userid)
        {
            var result = HttpContext.Session.GetString("user_items");

            if (result != null)
            {
                var existingItems = JsonConvert.DeserializeObject<List<CartViewModel>>(result);
                if(existingItems.Count() > 0)
                {
                    foreach( var item in existingItems)
                    {
                        tbOrder order = new tbOrder();
                        order.Status = "Pending";
                        order.OrderNumber = getUniqueCode();
                        order.Quantity = item.Quantity;
                        order.Price = item.Subtotal;
                        order.Address = address;
                        order.PhoneNumber = phonenumber;
                        order.Time = DateTime.Now;
                        order.UserID = userid;
                        await _iorder.CreateNewOrder(order);
                    }
                }
                List<CartViewModel> cvm = new List<CartViewModel>();
                HttpContext.Session.SetString("user_items", JsonConvert.SerializeObject(cvm));
            }
            return Ok();
        }

        public static string getUniqueCode()
        {
            return Guid.NewGuid().ToString("N");
        }

    }
}
