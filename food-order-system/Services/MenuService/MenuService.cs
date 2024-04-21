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
            var result = await _uow.menuRepo.GetWithoutTracking().Where(a => a.Status != "Deleted").ToListAsync();
            return result;
        }

        public async Task<tbMenu> GetMenuById(int id)
        {
            var result = await _uow.menuRepo.GetWithoutTracking().Where(a => a.MenuId == id && a.Status != "Deleted").FirstOrDefaultAsync();
            return result;           
        }

        public async Task<tbMenu> CreateNewMenu(tbMenu menu)
        {
            if(menu.MenuId > 0)
            {
                tbMenu existingMenu = await _uow.menuRepo.GetWithoutTracking().Where(a => a.MenuId == menu.MenuId).FirstOrDefaultAsync();
                if(menu.Image == null)
                {
                    menu.Image = existingMenu.Image;
                }
                var result = await _uow.menuRepo.UpdateAsync(menu);
            }
            else
            {
                var result = await _uow.menuRepo.InsertReturnAsync(menu);
                return result;
            }
            return new tbMenu();
        }

        public async Task<int> GetTotalMenu()
        {
            var result = await _uow.menuRepo.GetWithoutTracking().Where(a => a.Status != "Deleted").CountAsync();
            return result;
        }

        public async Task<int> DeleteMenu(int id)
        {
            tbMenu menu = await _uow.menuRepo.GetWithoutTracking().Where(a => a.MenuId == id).FirstOrDefaultAsync();
            if(menu != null)
            {
                menu.Status = "Deleted";
                await _uow.menuRepo.UpdateAsync(menu);
                return 1;
            }
            return 0;
        }
    }
}
