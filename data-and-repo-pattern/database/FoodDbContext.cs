using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace data_and_repo_pattern.database
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        { 
            
        }

        public virtual DbSet<tbUser> tbUser { get;set; }
        public virtual DbSet<tbMenu> tbMenu { get; set; }
        public virtual DbSet<tbOrder> tbOrder { get; set; }
    }
}
