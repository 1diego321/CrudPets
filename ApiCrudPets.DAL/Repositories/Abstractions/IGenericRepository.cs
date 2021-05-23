using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.DAL.Repositories.Abstractions
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
                                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                               string includeProperties = null);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        string includeProperties = null);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(int id);
    }
}
