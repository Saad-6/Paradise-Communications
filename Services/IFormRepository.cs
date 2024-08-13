using Paradise.Models;

namespace Paradise.Services
{
    public interface IFormRepository<T> where T : class 
    {
        IQueryable<T> GetQueryable();
        bool Insert(T entity);
        IList<T> GetAll();



        
    }
   
}
