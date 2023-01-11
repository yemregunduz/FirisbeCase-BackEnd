using FirisbeCase.Core.DynamicQuery;
using FirisbeCase.Core.Entities;
using FirisbeCase.Core.Wrappers.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
namespace FirisbeCase.Core.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext
    {
        protected TContext Context;
        public DbSet<TEntity> Table => Context.Set<TEntity>();
        public EfEntityRepositoryBase(TContext context)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
        }
        #region Insert Methods
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await SaveChangesAsync();
            return entity;

        }
        public virtual TEntity Add(TEntity entity)
        {
            Table.Add(entity);
            SaveChanges();
            return entity;
        }
        #endregion

        #region Get Methods
        public async Task<TEntity> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            if (include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>,IIncludableQueryable<TEntity, object>> include = null,
            int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = Table.AsQueryable();
            if (!enableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToPaginateAsync(index,size,0,cancellationToken);

            return await query.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic dynamic,Func<IQueryable<TEntity>,IIncludableQueryable<TEntity, object>>?include = null,
                 int index = 0, int size = 10,bool enableTracking = true,CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Table.AsQueryable().ToDynamic(dynamic);
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include != null) 
                queryable = include(queryable);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true)
        {
            var query = Table.AsQueryable();
            if (!enableTracking)
                query = Table.AsNoTracking();
            if (include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }
        #endregion

        #region SaveChanges Methods
        public int SaveChanges()
            => Context.SaveChanges();

        public Task<int> SaveChangesAsync()
            => Context.SaveChangesAsync();
        #endregion
    }
}

