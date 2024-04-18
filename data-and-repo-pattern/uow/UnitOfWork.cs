using data_and_repo_pattern.database;
using data_and_repo_pattern.repo;
using data_and_repo_pattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private FoodDbContext _ctx;
        private IRepository<tbUser> _userRepo;
        private IRepository<tbMenu> _menuRepo;
        private IRepository<tbOrder> _orderRepo;

        public UnitOfWork(FoodDbContext ctx)
        {
            _ctx = ctx;
        }


        ~UnitOfWork()
        {
            _ctx.Dispose();
        }

        public IRepository<tbUser> userRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new Repository<tbUser>(_ctx);
                }
                return _userRepo;
            }
        }

        public IRepository<tbMenu> menuRepo
        {
            get
            {
                if (_menuRepo == null)
                {
                    _menuRepo = new Repository<tbMenu>(_ctx);
                }
                return _menuRepo;
            }
        }

        public IRepository<tbOrder> orderRepo
        {
            get
            {
                if (_orderRepo == null)
                {
                    _orderRepo = new Repository<tbOrder>(_ctx);
                }
                return _orderRepo;
            }
        }

    }
}
