using BusinessLogic.User_Management.Interfaces;
using Repository.User_Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.User_Management.Implementations
{
    public class ActionRoleService : IActionRoleService
    {
        private readonly IActionRoleRepo _IActionRoleRepo;
        public ActionRoleService(IActionRoleRepo IActionRoleRepo)
        {
            _IActionRoleRepo = IActionRoleRepo;
        }
        public Task<bool> HaveAcces(string _RoleUser, string _Controller, string _Action, string _compagnie)
        {
           return _IActionRoleRepo.HaveAcces(_RoleUser, _Controller, _Action, _compagnie);
        }
    }
}
