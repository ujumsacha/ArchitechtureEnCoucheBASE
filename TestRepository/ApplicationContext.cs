using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestRepository
{
    public class ApplicationContext:DbContext
    {
        protected readonly IConfiguration _configuration;
        public ApplicationContext(DbContextOptions<ApplicationContext> option, IConfiguration configuration) : base(option)
        {
            _configuration = configuration;
        }

        public DbSet<Produit> DbProduit { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var conn = _configuration.GetConnectionString("DefaultConnection");
            //optionsBuilder.UseSqlServer(conn);
        }

    }
}