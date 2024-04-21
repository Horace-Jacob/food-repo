using data_and_repo_pattern.helper.OrderApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_admin.Controllers
{
    public class OrderController : Controller
    {
        IOrderApiRequest _iorder;
        public OrderController(IOrderApiRequest iorder)
        {
            _iorder = iorder;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> _orderdetails()
        {
            var result = await _iorder.GetAllOrders();
            return PartialView("_orderdetails", result);
        }

        public async Task<IActionResult> MarkAsDelivered(int id)
        {
            var result = await _iorder.UpdateOrderStatus(id);
            return Ok(result);
        }
    }
}
