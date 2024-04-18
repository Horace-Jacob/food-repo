using data_and_repo_pattern.database;
using data_and_repo_pattern.uow;
using Microsoft.EntityFrameworkCore;

namespace food_order_system.Services.MenuService
{
    public class MenuService : IMenuService
    {
        IUnitOfWork _uow;
        public MenuService(IUnitOfWork uow) 
        { 
            this._uow = uow;
        }

        public async Task<List<tbMenu>> GetAllMenus()
        {
            var result = await _uow.menuRepo.GetWithoutTracking().ToListAsync();
            return result;
        }

        public async Task<tbMenu> GetMenuById(int id)
        {
            var result = await _uow.menuRepo.GetWithoutTracking().Where(a => a.MenuId == id).FirstOrDefaultAsync();
            return result;           
        }

        public async Task<tbMenu> CreateNewMenu(tbMenu menu)
        {
            var result = await _uow.menuRepo.InsertReturnAsync(menu);
            return result;
        }
    }
}
