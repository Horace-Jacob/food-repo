using data_and_repo_pattern.database;
using data_and_repo_pattern.helper.UserApiRequest;
using data_and_repo_pattern.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_web.Controllers
{
    public class RegisterController : Controller
    {
        IUserApiRequest _iuserapirequest;
        public RegisterController(IUserApiRequest userApiRequest)
        {
            this._iuserapirequest = userApiRequest;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateNewUser(RegisterViewModel user)
        {
            UserViewModel uvm = await _iuserapirequest.CreateNewUser(user);
            return Ok(uvm);
        }
    }
}
