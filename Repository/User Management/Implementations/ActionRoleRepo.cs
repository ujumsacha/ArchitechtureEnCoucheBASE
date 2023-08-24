using Core.User_Management;
using Microsoft.EntityFrameworkCore;
using Repository.Implementations;
using Repository.User_Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.User_Management.Implementations
{
    public class ActionRoleRepo : BaseClasseRepo<ActionRole>, IActionRoleRepo
    {
        private readonly ApplicationContext Context;
        private readonly DbSet<ActionRole> _ActionRole;
        public ActionRoleRepo(ApplicationContext _context) : base(_context)
        {
            Context = _context;
            _ActionRole = Context.Set<ActionRole>();
        }

        public async Task<bool> HaveAcces(string _RoleUser, string _Controller, string _Action,string _compagnie)
        {
            if(!_ActionRole.Any(p=>p.r_CompanieID==_compagnie && p.r_Controller==_Controller.ToUpper() && p.r_Action==_Action.ToUpper() && p.r_id_Role==_RoleUser))
            {
                return false;
            }
            return true;
        }
    }
}
