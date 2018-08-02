namespace TA.DAL.Repositories
{
    using System;
    using System.Linq;

    public interface IBaseRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        int SaveChanges();
    }
}
