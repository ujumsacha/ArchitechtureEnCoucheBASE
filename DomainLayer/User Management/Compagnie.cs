using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User_Management
{
    public class Compagnie 
    {
        public string r_id { get; set; }
        public string r_created_by { get; set; }
        public string? r_update_by { get; set; }
        public bool r_is_delete { get; set; }
        public bool r_is_desactivate { get; set; }
        public DateTime r_created_on { get; set; }
        public DateTime? r_update_on { get; set; }
        public string r_NomComp { get; set; }
        public string r_DescriptionComp { get; set; }
        public IEnumerable<Utilisateur>? r_Utilisateurs { get; set; }
        public IEnumerable<Produit>? r_Produits { get; set; }
        public IEnumerable<Acheter>? r_Acheters { get; set; }
    }
}
