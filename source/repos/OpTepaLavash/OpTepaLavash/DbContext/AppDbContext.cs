using Microsoft.EntityFrameworkCore;
using OpTepaLavash.Models;

namespace OpTepaLavash.DB_Constants
{
    public class AppDbContext : DbContext // entity framework ni radnoyi o'zini ichida bo'ladi
    {

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString = "Host=localhost; port=5432; Database=oqtepalavash; User Id=postgres; Password=3;";
            optionsBuilder.UseNpgsql(connectionString);


        }
    }
}
