using data_and_repo_pattern.database;
using food_order_system.Services.MenuService;
using food_order_system.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _iorder;
        public OrderController(IOrderService iorder)
        {
            this._iorder = iorder;
        }

        [HttpGet("api/order/getall")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _iorder.GetAllOrders();
            return Ok(result);
        }

        [HttpGet("api/menu/getorderbyid")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _iorder.GetOrderById(id);
            return Ok(result);
        }
        [HttpGet("api/menu/getorderbyuserid")]
        public async Task<IActionResult> GetOrderByUserID(int userid)
        {
            var result = await _iorder.GetOrderByUserID(userid);
            return Ok(result);
        }


        [HttpPost("api/order/createorder")]
        public async Task<IActionResult> CreateNewOrder(tbOrder menu)
        {
            var result = await _iorder.CreateNewOrder(menu);
            return Ok(result);
        }

    }
}
