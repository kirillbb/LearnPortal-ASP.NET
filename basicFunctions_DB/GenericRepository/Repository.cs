namespace basicFunctions_DB.Repository
{
    using basicFunctions_DB.DAL;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    internal class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context = null;
        private DbSet<T> _dbSet = null;


        public Repository()
        {
            this._context = new ApplicationContext();
            _dbSet = _context.Set<T>();
        }
        public Repository(DbContext _context)
        {
            this._context = _context;
            _dbSet = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = _dbSet.Find(id);
            _dbSet.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }
        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Insert(T obj)
        {
            _dbSet.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
