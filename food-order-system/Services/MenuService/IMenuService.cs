using data_and_repo_pattern.database;

namespace food_order_system.Services.MenuService
{
    public interface IMenuService
    {
        Task<tbMenu> GetMenuById(int id);
        Task<List<tbMenu>> GetAllMenus();
        Task<tbMenu> CreateNewMenu(tbMenu menu);
        Task<int> GetTotalMenu();
        Task<int> DeleteMenu(int id);
    }
}
