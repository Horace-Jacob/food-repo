using data_and_repo_pattern.helper.OrderApiRequest;
using data_and_repo_pattern.helper.UserApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_web.Controllers
{
    public class ProfileController : Controller
    {
        IUserApiRequest _iuser;
        IOrderApiRequest _iorder;
        public ProfileController(IUserApiRequest iuser, IOrderApiRequest iorder)
        { 
            _iuser = iuser;
            _iorder = iorder;
        }
        public ActionResult Index() { return View(); }
        public async Task<IActionResult> _userprofile(int id)
        {
            var result = await _iuser.GetUserByID(id);
            return PartialView("_userprofile", result);
        }
        public async Task<IActionResult> _orderdetails(int userid)
        {
            var result = await _iorder.GetOrderByUserID(userid);
            return PartialView("_orderdetails", result);
        }

    }
}
