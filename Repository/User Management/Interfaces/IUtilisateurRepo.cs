using Core;
using Core.User_Management;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.User_Management.Interfaces
{
    public interface IUtilisateurRepo : IBaseClassRepo<Utilisateur>
    {
        public Task<Utilisateur> FindUsersByName(string name, CancellationToken _tokken);
        public Task<Utilisateur> FindUsersByEmail(string email,CancellationToken _tokken);
        public Task<bool> AddUserToRole(string _UserId, string _RoleId, CancellationToken _tokken);
        //public Task<Role> GetRoleOfUser(string _UserId, CancellationToken _tokken);
        public Task<bool> RemoveRoleOfUser(string _UserId, CancellationToken _tokken);

    }
}
