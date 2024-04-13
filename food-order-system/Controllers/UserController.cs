using data_and_repo_pattern.uow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace food_order_system.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IUnitOfWork _uow;

        public UserController(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        [HttpGet("api/user/getall")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _uow.userRepo.GetWithoutTracking().ToListAsync();
            return Ok(result);
        }
    }
}
