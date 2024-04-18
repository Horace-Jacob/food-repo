using data_and_repo_pattern.database;
using data_and_repo_pattern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.helper.MenuApiRequest
{
    public interface IMenuApiRequest
    {
        Task<tbMenu> GetMenuById(int id);
        Task<List<tbMenu>> GetAllMenus();
        Task<tbMenu> CreateNewMenu(tbMenu menu);
    }
}
