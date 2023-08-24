using Core;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class BaseClasseRepo<T> : IBaseClassRepo<T>  where T : BaseClass
    {
        public readonly ApplicationContext Context;
        private readonly DbSet<T> Entite;
        public BaseClasseRepo(ApplicationContext _context)
        {
            Context = _context;
            Entite = Context.Set<T>();
        }
        public async Task<bool> Create(T _baseclass,CancellationToken token)
        {
            //*************************************Cancel task ***********************************************************
            //CancellationTokenSource cnl = new CancellationTokenSource();
            //cnl.CancelAfter(5000);
            
            //*************************************Cancel task ***********************************************************

            if (_baseclass == null)    
                return false;
            _baseclass.r_is_delete = false;
            _baseclass.r_is_desactivate = false;
            _baseclass.r_created_on = DateTime.Now;
            _baseclass.r_id= Guid.NewGuid().ToString();
            

            await Entite.AddAsync(_baseclass, token);
            await SaveChange();
            return true;
        }
        public async Task<bool> Delete(string id, string _U_id, CancellationToken _tokken)
        {
           var result = await Entite.Where(p => p.r_id == id && p.r_CompanieID == _U_id).FirstOrDefaultAsync(_tokken);
            if (result == null)
                return false;
            result.r_is_delete = true;
            Entite.Entry(result);
            await SaveChange();
            return true;
        }
        public async Task<bool> Desactivate(T t, string _U_id, CancellationToken token)
        {
            var result = await Entite.Where(p => p.r_id == t.r_id && p.r_CompanieID == _U_id).FirstOrDefaultAsync(token);
            if (result == null)
                return false;
            result.r_is_desactivate = true;
            Entite.Entry(result);
            await SaveChange();
            return true;
        }
        public async Task<IEnumerable <T>> GetAll(string _U_id,CancellationToken _tokken)
        {
            return await Entite.Where(p=>p.r_is_delete == false && p.r_CompanieID == _U_id).ToListAsync(_tokken);
        }
        public async Task<IEnumerable<T>> GetAllActivate(string _U_id, CancellationToken _tokken)
        {
            return await Entite.Where(p => p.r_is_delete == false && p.r_CompanieID == _U_id && p.r_is_desactivate==false).ToListAsync(_tokken);
        }
        public async Task<T>  GetOne(string _id, string _U_id,CancellationToken _tokken)
        {
            return await Entite.Where(p => p.r_id == _id && p.r_is_delete==false && p.r_CompanieID == _U_id).FirstOrDefaultAsync(_tokken);
        }
        public async Task SaveChange()
        {
            await Context.SaveChangesAsync();
        }
        public async Task<bool> update(T t, string _U_id, CancellationToken _tokken)
        {
            var result = await Entite.Where(p => p.r_id == t.r_id && p.r_created_by == _U_id).FirstOrDefaultAsync(_tokken);
            if (result == null)
                return false;
            result.r_is_delete = true;
            Entite.Entry(result);
            await SaveChange();
            return true;
        }

    }
}
