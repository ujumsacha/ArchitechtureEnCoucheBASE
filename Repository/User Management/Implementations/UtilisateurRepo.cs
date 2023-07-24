using Core;
using Core.User_Management;
using Microsoft.EntityFrameworkCore;
using Repository.BdFolder;
using Repository.Implementations;
using Repository.Interfaces;
using Repository.Interfaces.User_Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.User_Management.Implementations
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

        public async Task<bool> AddUserToRole(string _UserID, string _RoleId, CancellationToken _tokken)
        {
            var User =await Entite.Where(p=>p.r_id==_UserID && p.r_id_Role== _RoleId).FirstOrDefaultAsync(_tokken);
            if (User == null)
                return false;
            User.r_id_Role = _RoleId;
            Entite.Entry(User);
            await SaveChange();
            return true;

        }

        public async Task<Utilisateur> FindUsersByEmail(string email, CancellationToken _tokken)
        {
            return await Entite.Where(p=>p.r_email==email).FirstOrDefaultAsync(_tokken);
        }

        public async Task<Utilisateur> FindUsersByName(string name, CancellationToken _tokken)
        {
            return await  Entite.Where(p => p.r_Nom.Contains(name)).FirstOrDefaultAsync(_tokken);
        }

        public Task<bool> RemoveRoleOfUser(string _UserId, CancellationToken _tokken)
        {
            throw new NotImplementedException();
        }
    }
}
