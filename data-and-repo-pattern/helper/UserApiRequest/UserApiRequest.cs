using data_and_repo_pattern.database;
using data_and_repo_pattern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.helper.UserApiRequest
{
    public class UserApiRequest : ApiRequestFactory, IUserApiRequest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserApiRequest(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<List<tbUser>> GetAllUsers()
        {
            string url = $"api/user/getall";
            var result = await GetRequest<List<tbUser>>(url.route(Request.FoodOrderApi));
            return result;
        }

        public async Task<tbUser> GetUserByID(int id)
        {
            string url = $"api/user/getuserbyid?id={id}";
            var result = await GetRequest<tbUser>(url.route(Request.FoodOrderApi));
            return result;
        }

        public async Task<UserViewModel> CreateNewUser(RegisterViewModel user)
        {
            string url = $"api/user/createuser";
            var result = await PostDiffRequest<RegisterViewModel, UserViewModel>(url.route(Request.FoodOrderApi), user);
            return result;
        }
        public async Task<UserViewModel> LoginUser(tbUser user)
        {
            string url = $"api/user/login";
            var result = await PostDiffRequest<tbUser, UserViewModel>(url.route(Request.FoodOrderApi), user);
            return result;
        }

    }
}
