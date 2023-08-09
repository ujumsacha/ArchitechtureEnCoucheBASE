using Core.User_Management;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.User_Management.Interfaces
{
    public interface IActionRoleRepo : IBaseClassRepo<ActionRole>
    {
        public Task<bool> HaveAcces(string _RoleUser,string _Controller, string _Action, string _compagnie);
    }
}
