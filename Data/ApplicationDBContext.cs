using Microsoft.EntityFrameworkCore;
using ProjectKMITL.Models;

namespace ProjectKMITL.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }


    }
}
