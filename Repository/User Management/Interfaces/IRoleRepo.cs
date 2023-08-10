using Core.User_Management;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.User_Management.Interfaces
{
    public interface IRoleRepo : IBaseClassRepo<Role>
    {
        public Task<Role> GetRoleofUser(string _UserId, string _U_id);
    }
}
