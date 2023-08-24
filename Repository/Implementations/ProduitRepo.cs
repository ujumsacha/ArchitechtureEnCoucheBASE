using Core;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class ProduitRepo : BaseClasseRepo<Produit>,IproduitRepo
    {
        private readonly ApplicationContext Context;
        private readonly DbSet<Produit> Entite;
        public ProduitRepo(ApplicationContext _context) : base(_context)
        {
            Context = _context;
            Entite = Context.Set<Produit>();
        }
    }
}
