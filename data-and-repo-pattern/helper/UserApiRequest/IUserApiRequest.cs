using data_and_repo_pattern.database;
using data_and_repo_pattern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.helper.UserApiRequest
{
    public interface IUserApiRequest
    {
        Task<List<tbUser>> GetAllUsers();
        Task<UserViewModel> LoginUser(tbUser user);
        Task<UserViewModel> CreateNewUser(RegisterViewModel user);
        Task<tbUser> GetUserByID(int id);

    }
}
