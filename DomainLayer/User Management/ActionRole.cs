using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User_Management
{
    public class ActionRole : BaseClass
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string r_Uri { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string r_Controller { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string r_Action { get; set; }


        public string r_id_Role { get; set; }
        public Role r_Role { get; set; }
    }
}
