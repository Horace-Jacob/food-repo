using data_and_repo_pattern.database;
using data_and_repo_pattern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.helper.MenuApiRequest
{
    public class MenuApiRequest : ApiRequestFactory, IMenuApiRequest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuApiRequest(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<List<tbMenu>> GetAllMenus()
        {
            string url = $"api/menu/getall";
            var result = await GetRequest<List<tbMenu>>(url.route(Request.FoodOrderApi));
            return result;
        }

        public async Task<tbMenu> GetMenuById(int id)
        {
            string url = $"api/menu/getmenubyid?id={id}";
            var result = await GetRequest<tbMenu>(url.route(Request.FoodOrderApi));
            return result;
        }
        public async Task<tbMenu> CreateNewMenu(tbMenu menu)
        {
            string url = $"api/menu/createmenu";
            var result = await PostRequest<tbMenu>(url.route(Request.FoodOrderApi), menu);
            return result;
        }
        public async Task<int> GetTotalMenu()
        {
            string url = $"api/menu/gettotalmenu";
            var result = await GetRequest<int>(url.route(Request.FoodOrderApi));
            return result;
        }
        public async Task<int> DeleteMenu(int id)
        {
            string url = $"api/menu/deletemenu?id={id}";
            var result = await GetRequest<int>(url.route(Request.FoodOrderApi));
            return result;
        }


    }
}
