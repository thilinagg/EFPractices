using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetQueryable();
        List<T> GetAll();
        List<T> GetList(Func<T, bool> where);
        T GetSingle(Func<T, bool> where);
        T Insert(T entity);
        int Delete(Func<T, bool> where, T entity);
        T Update(Func<T, bool> where, T entity);
        T Update(T entity);
        bool IsExist(Func<T, bool> where);
    }
}
