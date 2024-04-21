using data_and_repo_pattern.database;
using data_and_repo_pattern.uow;
using data_and_repo_pattern.ViewModel;
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

        public async Task<int> GetDeliveredTotal()
        {
            var result = await _uow.orderRepo.GetWithoutTracking().Where(a => a.Status == "Delivered").CountAsync();
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

        public async Task<OrderDetailViewModel> GetOrderDetail(int id)
        {
            OrderDetailViewModel odvm = new OrderDetailViewModel();
            tbOrder order = await _uow.orderRepo.GetWithoutTracking().Where(a => a.OrderId == id).FirstOrDefaultAsync();
            if(order != null)
            {
                tbUser user = await _uow.userRepo.GetWithoutTracking().Where(a => a.UserID == order.UserID).FirstOrDefaultAsync();
                odvm.Status = order.Status;
                odvm.Name = user.Username;
                odvm.Address = order.Address;
                odvm.Time = order.Time;
                odvm.Price = order.Price;
                odvm.Phone = order.PhoneNumber;
                odvm.OrderItem = order.OrderItem;
                odvm.OrderId = order.OrderId;
                odvm.Quantity = order.Quantity;
                return odvm;
            }
            return odvm;
        }

        public async Task<int> GetPendingTotal()
        {
            var result = await _uow.orderRepo.GetWithoutTracking().Where(a => a.Status == "Pending").CountAsync();
            return result;
        }

        public async Task<int> UpdateOrderStatus(int id)
        {
            tbOrder order = await _uow.orderRepo.GetWithoutTracking().Where(a => a.OrderId == id).FirstOrDefaultAsync();
            if(order != null)
            {
                order.Status = "Delivered";
                await _uow.orderRepo.UpdateAsync(order);
                return 1;
            }
            return 0;
        }
    }
}
