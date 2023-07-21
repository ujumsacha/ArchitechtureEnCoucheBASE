using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Produit:BaseClass
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string r_Nom { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(500)]
        public string r_description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [MaxLength(255)]
        public string r_prix { get; set; }
    }
}
