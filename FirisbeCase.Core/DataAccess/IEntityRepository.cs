using FirisbeCase.Core.DynamicQuery;
using FirisbeCase.Core.Entities;
using FirisbeCase.Core.Wrappers.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FirisbeCase.Core.DataAccess
{
    public interface IEntityRepository<TEntity>
        where TEntity : BaseEntity,new()
    {
        Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                   int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default);
        Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic dynamic,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                         int index = 0, int size = 10, bool enableTracking = true,
                                         CancellationToken cancellationToken = default);
        TEntity Add(TEntity entity);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
                IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true);
        Task<TEntity> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool tracking = true);
        Task<TEntity> AddAsync(TEntity entity);

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
