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

namespace Repository.BdFolder

{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {

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
            

        }
        
    }
}
