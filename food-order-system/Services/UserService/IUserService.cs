using data_and_repo_pattern.database;
using data_and_repo_pattern.ViewModel;

namespace food_order_system.Services.UserService
{
    public interface IUserService
    {
        Task<List<tbUser>> GetAllUsers();
        Task<UserViewModel> CreateNewUser(RegisterViewModel user);
        Task<UserViewModel> LoginUser(tbUser user);
        Task<tbUser> GetUserByID(int id);
        Task<int> GetUserCount();
    }
}
