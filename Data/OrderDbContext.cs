using Microsoft.EntityFrameworkCore;
using ProjectKMITL.Models;

namespace ProjectKMITL.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) :base(options)
        {

        }

        public DbSet<OrderModel> Orders { get; set; }

    }
}
