using Core;
using Microsoft.EntityFrameworkCore;
using Repository.BdFolder;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class BaseClasseRepo<T> : IBaseClassRepo<BaseClass>  where T : BaseClass
    {
        public readonly ApplicationContext Context;
        private readonly DbSet<T> Entite;
        public BaseClasseRepo(ApplicationContext _context)
        {
            Context = _context;
            Entite = Context.Set<T>();
        }

        public bool Create(BaseClass _t)
        {
            if(_t == null)    
                return false;
            _t.r_is_delete = false;
            _t.r_is_desactivate = false;
            _t.r_created_on = DateTime.Now;
            _t.r_id= new Guid(Guid.NewGuid().ToString());

            Entite.AddAsync(_t);
        }

        public bool Delete(Guid id, Guid _U_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseClass> GetAll(Guid _U_id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseClass>  GetOne(string _id, Guid _U_id)
        {
            return await Entite.Where()
        }

        public async Task SaveChange(CancellationToken _tokken)
        {
           await Context.SaveChangesAsync(_tokken);
        }

        public bool update(BaseClass t)
        {
            throw new NotImplementedException();
        }
    }
}
