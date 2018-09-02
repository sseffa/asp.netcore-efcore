using LearningEFCore.Data;
using LearningEFCore.Interfaces;
using System.Collections.Generic;

namespace LearningEFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext context;

        public GenericRepository(DataContext ctx) => context = ctx;

        public virtual T Get(long id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual void Create(T newDataObject)
        {
            context.Add<T>(newDataObject);
            context.SaveChanges();
        }

        public virtual void Delete(long id)
        {
            context.Remove<T>(Get(id));
            context.SaveChanges();
        }

        public virtual void Update(T changedDataObject)
        {
            context.Update<T>(changedDataObject);
            context.SaveChanges();
        }
    }
}
