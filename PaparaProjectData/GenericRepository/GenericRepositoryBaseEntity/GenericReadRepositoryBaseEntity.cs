using Microsoft.EntityFrameworkCore;
using PaparaFinalBase.Entity;
using PaparaFinalData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.GenericRepository.GenericRepositoryBaseEntity
{
    public class GenericReadRepositoryBaseEntity<TEntity> : IGenericReadRepositoryBaseEntity<TEntity> where TEntity : BaseEntity
    {
        private readonly PaparaProjectDbContext dbContext;

        public GenericReadRepositoryBaseEntity(PaparaProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<TEntity>> GetAll(params string[] includes)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
            query = query.Where(x => x.IsActive);
            return await EntityFrameworkQueryableExtensions.ToListAsync(query);
        }

        public async Task<TEntity?> GetById(int Id, params string[] includes)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
            return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query, x => x.Id == Id && x.IsActive);
        }
        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
            return query.Where(expression).FirstOrDefault();
        }
    }
}
