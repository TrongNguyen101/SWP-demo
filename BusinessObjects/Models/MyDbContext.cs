using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {}
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("TrongConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}