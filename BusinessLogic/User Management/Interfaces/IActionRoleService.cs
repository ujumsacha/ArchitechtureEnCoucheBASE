using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.User_Management.Interfaces
{
    public interface IActionRoleService
    {
        public Task<bool> HaveAcces(string _RoleUser, string _Controller, string _Action, string _compagnie);
    }
}
