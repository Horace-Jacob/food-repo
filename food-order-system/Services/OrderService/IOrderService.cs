using data_and_repo_pattern.database;

namespace food_order_system.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<tbOrder>> GetAllOrders();
        Task<tbOrder> GetOrderById(int id);
        Task<tbOrder> CreateNewOrder(tbOrder order);
        Task<List<tbOrder>> GetOrderByUserID(int userid);
    }
}
