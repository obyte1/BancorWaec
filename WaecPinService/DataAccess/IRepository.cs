using System.Linq.Expressions;
using WaecPinService.Model;

namespace WaecPinService.DataAccess
{
    
    }

    public interface IRepository<T> where T : EntityBase
    {
        Task DeleteAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<T> GetOneAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task InsertAsync(T entity);
        void Reload(ref T entity);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }

}
