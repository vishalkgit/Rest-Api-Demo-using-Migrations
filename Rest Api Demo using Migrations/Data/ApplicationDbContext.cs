using Microsoft.EntityFrameworkCore;
using Rest_Api_Demo_using_Migrations.Models.Entitiess;

namespace Rest_Api_Demo_using_Migrations.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Employee> Employees { get; set; }

    }
}
