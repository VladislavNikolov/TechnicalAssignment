namespace TA.BLL.Services
{
    using System.Collections.Generic;

    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);
    }
}
