using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Utilisateur: BaseClass
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
        [DataType(DataType.EmailAddress)]
        [MaxLength(255)]
        public string r_email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        public string r_password { get; set; }
    }
}
