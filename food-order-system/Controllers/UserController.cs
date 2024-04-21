using data_and_repo_pattern.database;
using data_and_repo_pattern.uow;
using data_and_repo_pattern.ViewModel;
using food_order_system.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace food_order_system.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _iuser;

        public UserController(IUserService iuser)
        {
            this._iuser = iuser;
        }
        [HttpGet("api/user/getall")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _iuser.GetAllUsers();
            return Ok(result);
        }
        [HttpGet("api/user/getuserbyid")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            var result = await _iuser.GetUserByID(id);
            return Ok(result);
        }


        [HttpPost("api/user/createuser")]
        public async Task<IActionResult> CreateNewUser(RegisterViewModel user)
        {
            var result = await _iuser.CreateNewUser(user);
            return Ok(result);
        }
        [HttpPost("api/user/login")]
        public async Task<IActionResult> LoginUser(tbUser user)
        {
            var result = await _iuser.LoginUser(user);
            return Ok(result);
        }

        [HttpGet("api/user/getusers")]
        public async Task<IActionResult> GetUserCount()
        {
            var result = await _iuser.GetUserCount();
            return Ok(result);
        }
    }
}
