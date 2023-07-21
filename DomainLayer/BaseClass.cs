using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BaseClass
    {
        public Guid r_id { get; set; } = new Guid();
        public Guid created_by { get; set; }
        public Guid update_by { get; set; } 
        public bool r_is_delete { get; set; }
        public bool r_is_desactivate { get; set; }
        public DateTime r_created_on { get; set; }
        public DateTime r_update_on { get; set; }
    }
}
