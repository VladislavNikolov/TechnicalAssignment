using System.Collections.Generic;

namespace TA.BLL.Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);
    }
}
