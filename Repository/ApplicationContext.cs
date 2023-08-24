using Core;
using Core.User_Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository

{
    public class ApplicationContext : DbContext
    {
        protected readonly IConfiguration _configuration;    
        public ApplicationContext(DbContextOptions<ApplicationContext> option, IConfiguration configuration) : base(option)
        {
            _configuration = configuration;
        }

        public DbSet<Utilisateur> DbUtilisateur { get; set; }
        public DbSet<Produit> DbProduit { get; set; }
        public DbSet<Acheter> DbAcheter { get; set; }
        public DbSet<Role> DbRole { get; set; }
        public DbSet<Compagnie> DbCompagnie { get; set; }
        public DbSet<ActionRole> DbActionRole { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conn);
        }

    }
}
