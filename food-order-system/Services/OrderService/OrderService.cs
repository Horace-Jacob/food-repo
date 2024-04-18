using data_and_repo_pattern.database;
using data_and_repo_pattern.uow;
using Microsoft.EntityFrameworkCore;

namespace food_order_system.Services.OrderService
{
    public class OrderService : IOrderService
    {
        IUnitOfWork _uow;
        public OrderService(IUnitOfWork uow) 
        { 
            this._uow = uow;
        }

        public async Task<tbOrder> CreateNewOrder(tbOrder order)
        {
            var result = await _uow.orderRepo.InsertReturnAsync(order);
            return result;
        }

        public async Task<List<tbOrder>> GetAllOrders()
        {
            var result = await _uow.orderRepo.GetWithoutTracking().ToListAsync();
            return result;
        }

        public async Task<tbOrder> GetOrderById(int id)
        {
            var result = await _uow.orderRepo.GetWithoutTracking().Where(a => a.OrderId == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<tbOrder>> GetOrderByUserID(int userid)
        {
            var result = await _uow.orderRepo.GetWithoutTracking().Where(a => a.UserID == userid).ToListAsync();
            return result;
        }
    }
}
