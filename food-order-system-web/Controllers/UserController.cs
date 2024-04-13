using data_and_repo_pattern.helper.UserApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace food_order_system_web.Controllers
{
    public class UserController : Controller
    {
        IUserApiRequest _iuser;
        public UserController(IUserApiRequest iuser)
        {
            _iuser = iuser;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
