using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User_Management
{
    public class Role : BaseClass
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string r_NomRole { get; set; }
        public IEnumerable<Utilisateur>? r_utilisateurs { get; set; }
        public IEnumerable<ActionRole>? r_actionroles { get; set; }
    }
}
