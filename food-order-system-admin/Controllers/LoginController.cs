using data_and_repo_pattern.database;
using data_and_repo_pattern.helper.UserApiRequest;
using data_and_repo_pattern.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_admin.Controllers
{
    public class LoginController : Controller
    {
        IUserApiRequest _iuser;
        public LoginController(IUserApiRequest iuser) 
        { 
            _iuser = iuser;
        }
        public ActionResult Index() { return View(); }
        public async Task<IActionResult> LoginUser(tbUser user)
        {
            UserViewModel uvm = await _iuser.LoginUser(user);
            return Ok(uvm);
        }
    }
}
