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
    public class AcheterRepo : BaseClasseRepo<Acheter>,IAcheterRepo
    {
        private readonly ApplicationContext Context;
        private readonly DbSet<Acheter> Entite;
        public AcheterRepo(ApplicationContext _context) : base(_context)
        {
            Context = _context;
            Entite = Context.Set<Acheter>();
        }
    }
}
