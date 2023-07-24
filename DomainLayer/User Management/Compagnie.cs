using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User_Management
{
    public class Compagnie :BaseClass
    {
        public string r_NomComp { get; set; }
        public IEnumerable<Utilisateur>? r_Utilisateurs { get; set; }
    }
}
