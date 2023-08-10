using Core.User_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class UtilisateurReceiveRoleActionDTO
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(15)]
        public string r_Nom { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string r_prenoms { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string r_contact { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(255)]
        public string r_email { get; set; }

        public string r_id_Role { get; set; }
        public Role r_Role { get; set; }
    }
}
