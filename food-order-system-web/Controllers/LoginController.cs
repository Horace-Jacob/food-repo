using data_and_repo_pattern.database;
using data_and_repo_pattern.helper.UserApiRequest;
using data_and_repo_pattern.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_web.Controllers
{
    public class LoginController : Controller
    {
        IUserApiRequest _userApiRequest;
        public LoginController(IUserApiRequest userApiRequest) 
        { 
            _userApiRequest = userApiRequest;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoginUser(tbUser user)
        {
            UserViewModel uvm = await _userApiRequest.LoginUser(user);
            return Ok(uvm);
        }

    }
}
