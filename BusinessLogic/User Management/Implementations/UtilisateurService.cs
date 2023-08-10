using BusinessLogic.DTO;
using BusinessLogic.User_Management.Interfaces;
using Mapster;
using Repository.Interfaces.User_Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.User_Management.Implementations
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepo _utilisateurRepo;
        public UtilisateurService(IUtilisateurRepo utilisateurRepo)
        {
            _utilisateurRepo = utilisateurRepo;
        }
        public async Task<UtilisateurReceiveRoleActionDTO> GetUserWithEmail(string _email, string _compagnieID)
        {
            try
            {
                UtilisateurReceiveRoleActionDTO result = new UtilisateurReceiveRoleActionDTO();
                return _utilisateurRepo.FindUsersByEmail(_email, _compagnieID).Result.Adapt<UtilisateurReceiveRoleActionDTO>();
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }
    }
}
