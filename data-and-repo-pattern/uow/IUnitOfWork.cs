using data_and_repo_pattern.database;
using data_and_repo_pattern.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.uow
{
    public interface IUnitOfWork
    {
        IRepository<tbUser> userRepo { get; }
        IRepository<tbMenu> menuRepo { get; }
        IRepository<tbOrder> orderRepo { get; }

    }
}
