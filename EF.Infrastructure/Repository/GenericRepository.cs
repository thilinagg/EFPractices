using EF.Core.Interfaces;
using EF.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Infrastructure.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbSet<T> EntitySet { get; set; }
        protected InterviewEntities Context { get; set; }

        public GenericRepository(InterviewEntities context)
        {
            Context = context;
            EntitySet = Context.Set<T>();
        }

        public IQueryable<T> GetQueryable()
        {
            return EntitySet.AsQueryable<T>();
        }

        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            list = EntitySet.ToList();
            return list;
        }

        public List<T> GetList(Func<T, bool> where)
        {
            List<T> list = new List<T>();
            list = EntitySet.Where(where).ToList();
            return list;
        }

        public T GetSingle(Func<T, bool> where)
        {
            return EntitySet.FirstOrDefault(where);
        }

        public T Insert(T entity)
        {
            EntitySet.Add(entity);
            Context.SaveChanges();
            return entity;
        }
        public int Delete(Func<T, bool> where, T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                EntitySet.Attach(entity);
            }
            EntitySet.Remove(entity);
            return Context.SaveChanges();


        }

        public T Update(Func<T, bool> where, T entity)
        {
            T obj = GetSingle(where);
            Context.Entry(obj).CurrentValues.SetValues(entity);
            Context.SaveChanges();
            return obj;

        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;

        }
        public bool IsExist(Func<T, bool> where)
        {
            return EntitySet.Any(where);
        }
    }
}
