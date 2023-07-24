using Core.User_Management;
using Microsoft.EntityFrameworkCore;
using Repository.BdFolder;
using Repository.Implementations;
using Repository.Interfaces;
using Repository.User_Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.User_Management.Implementations
{
    public class RoleRepo : BaseClasseRepo<Role>, IRoleRepo
    {
        private readonly ApplicationContext Context;
        private readonly DbSet<Role> _Roles;
        public RoleRepo(ApplicationContext _context) : base(_context)
        {
            Context = _context;
            _Roles = Context.Set<Role>();
        }

        public Task<Role> GetRoleofUser(string _UserId)
        {
            throw new NotImplementedException();
        }
    }
}
