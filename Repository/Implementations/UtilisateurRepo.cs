using Core;
using Microsoft.EntityFrameworkCore;
using Repository.BdFolder;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UtilisateurRepo : BaseClasseRepo<Utilisateur>, IUtilisateurRepo
    {
        private readonly ApplicationContext Context;
        private readonly DbSet<Utilisateur> Entite;
        public UtilisateurRepo(ApplicationContext _context) : base(_context)
        {
            Context = _context;
            Entite = Context.Set<Utilisateur>();
        }
    }
}
