using data_and_repo_pattern.database;
using data_and_repo_pattern.repo;
using Infra.Repository;
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

    }
}
