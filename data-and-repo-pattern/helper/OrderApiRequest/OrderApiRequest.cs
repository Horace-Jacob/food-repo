using data_and_repo_pattern.database;
using data_and_repo_pattern.helper.MenuApiRequest;
using data_and_repo_pattern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.helper.OrderApiRequest
{
    public class OrderApiRequest : ApiRequestFactory, IOrderApiRequest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OrderApiRequest(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<List<tbOrder>> GetAllOrders()
        {
            string url = $"api/order/getall";
            var result = await GetRequest<List<tbOrder>>(url.route(Request.FoodOrderApi));
            return result;
        }

        public async Task<tbOrder> GetOrderById(int id)
        {
            string url = $"api/order/getorderbyid?id={id}";
            var result = await GetRequest<tbOrder>(url.route(Request.FoodOrderApi));
            return result;
        }
        public async Task<List<tbOrder>> GetOrderByUserID(int userid)
        {
            string url = $"api/menu/getorderbyuserid?userid={userid}";
            var result = await GetRequest<List<tbOrder>>(url.route(Request.FoodOrderApi));
            return result;
        }

        public async Task<tbOrder> CreateNewOrder(tbOrder order)
        {
            string url = $"api/order/createorder";
            var result = await PostRequest<tbOrder>(url.route(Request.FoodOrderApi), order);
            return result;
        }
        public async Task<int> GetPendingTotal()
        {
            string url = $"api/menu/getpendingtotal";
            var result = await GetRequest<int>(url.route(Request.FoodOrderApi));
            return result;
        }
        public async Task<int> GetDeliveredTotal()
        {
            string url = $"api/menu/getdeliveredtotal";
            var result = await GetRequest<int>(url.route(Request.FoodOrderApi));
            return result;
        }

        public async Task<int> UpdateOrderStatus(int id)
        {
            string url = $"api/menu/updateorderstatus?id={id}";
            var result = await GetRequest<int>(url.route(Request.FoodOrderApi));
            return result;
        }

        public async Task<OrderDetailViewModel> GetOrderDetail(int id)
        {
            string url = $"api/menu/getorderdetails?id={id}";
            var result = await GetRequest<OrderDetailViewModel>(url.route(Request.FoodOrderApi));
            return result;
        }

    }
}
