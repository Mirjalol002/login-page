using DemoApp.Domain.Constants;
using DemoApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DBContants.CONNECTION_STRING);
        }


    }
}
