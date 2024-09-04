using InCommPayment.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace InCommPayment.Infra.Context
{
    public class DBContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public DBContext()
        {
            
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
    }
}
