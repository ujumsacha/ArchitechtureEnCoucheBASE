using Core.User_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [NotMapped]
    public class BaseClass
    {
        public string r_id { get; set; }
        public string r_created_by { get; set; }
        public string? r_update_by { get; set; } 
        public bool r_is_delete { get; set; }
        public bool r_is_desactivate { get; set; }
        public DateTime r_created_on { get; set; }
        public DateTime? r_update_on { get; set; }

        public string  r_CompanieID { get; set; }
        public Compagnie  r_Companie { get; set; }


    }
}
