using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepository;

namespace TestService
{
    public class ProduitService : IproduitService
    {
        private readonly IproduitRepo iproduitrepo;
        public ProduitService(IproduitRepo _iproduitrepo)
        {
            iproduitrepo = _iproduitrepo;
        }
    }
}
