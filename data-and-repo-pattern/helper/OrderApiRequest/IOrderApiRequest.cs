using data_and_repo_pattern.database;
using data_and_repo_pattern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.helper.OrderApiRequest
{
    public interface IOrderApiRequest
    {
        Task<List<tbOrder>> GetAllOrders();
        Task<tbOrder> GetOrderById(int id);
        Task<tbOrder> CreateNewOrder(tbOrder order);
        Task<List<tbOrder>> GetOrderByUserID(int userid);
        Task<int> GetPendingTotal();
        Task<int> GetDeliveredTotal();
        Task<int> UpdateOrderStatus(int id);
        Task<OrderDetailViewModel> GetOrderDetail(int id);


    }
}
