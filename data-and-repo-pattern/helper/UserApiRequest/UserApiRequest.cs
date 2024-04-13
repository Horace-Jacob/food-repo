using data_and_repo_pattern.database;
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
    }
}
