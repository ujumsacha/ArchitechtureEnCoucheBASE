using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.User_Management.Interfaces
{
    public interface IUtilisateurService
    {
        public Task<UtilisateurReceiveRoleActionDTO> GetUserWithEmail(string _email,string _compagnieID );
        
    }
}
