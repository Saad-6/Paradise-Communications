using Microsoft.EntityFrameworkCore;
using Paradise.Data;
using Paradise.Models;

namespace Paradise.Services
{
    public class FormRepository<T> :BasicInfo, IFormRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public FormRepository(AppDbContext context)
        { 
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public bool Insert(T entity)
        {
           if(entity == null)
            {
                return false;
            }
           _dbSet.Add(entity);
           _context.SaveChanges();
            return true;
        }
    }
}
