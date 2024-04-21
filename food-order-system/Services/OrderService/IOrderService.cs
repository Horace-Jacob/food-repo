using data_and_repo_pattern.database;
using data_and_repo_pattern.ViewModel;

namespace food_order_system.Services.OrderService
{
    public interface IOrderService
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
