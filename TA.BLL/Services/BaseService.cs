namespace TA.BLL.Services
{
    using DAL.Repositories;

    public abstract class BaseService<T> where T : class
    {
        protected IBaseRepository<T> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }
    }
}
