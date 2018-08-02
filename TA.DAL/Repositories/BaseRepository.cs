namespace TA.DAL.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository()
            : this(new TADbContext())
        {
        }

        public BaseRepository(TADbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return this.Context.Set<T>().AsQueryable();
        }

        public virtual T GetById(object id)
        {
            return this.Context.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
