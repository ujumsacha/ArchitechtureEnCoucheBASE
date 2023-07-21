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
        public IEnumerable<T> GetAll(Guid _U_id);
        public T GetOne(Guid _id,Guid _U_id);
        public bool Delete(Guid id, Guid _U_id);
        public bool update(T t);
        public bool Create(T t);
        public void SaveChange();

    }
}
