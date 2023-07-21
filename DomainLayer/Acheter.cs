using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Acheter : BaseClass
    {
        [Required]
        [DataType(DataType.Text)]
        public Guid  r_id_produit { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public Guid  r_id_utilisateur { get; set; }
    }
}
