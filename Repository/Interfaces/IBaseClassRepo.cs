using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;


namespace Repository.Interfaces
{
    public interface IBaseClassRepo<T> where T : BaseClass
    {
        public Task<IEnumerable<T>> GetAll(string _U_id, CancellationToken _tokken);
        public Task<T> GetOne(string _id, string _U_id, CancellationToken _tokken);
        public Task<bool> Delete(string id, string _U_id, CancellationToken _tokken);
        public Task<bool> update(T t, string _U_id, CancellationToken _tokken);
        public Task<bool> Create(T t, CancellationToken token);
        public Task SaveChange();

    }
}
