using data_and_repo_pattern.helper.OrderApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_admin.Controllers
{
    public class DetailController : Controller
    {
        IOrderApiRequest _iorder;
        public DetailController(IOrderApiRequest iorder)
        {
            _iorder = iorder;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _orderitems(int id)
        {
            var result = await _iorder.GetOrderDetail(id);
            return PartialView("_orderitems", result);
        }
    }
}
