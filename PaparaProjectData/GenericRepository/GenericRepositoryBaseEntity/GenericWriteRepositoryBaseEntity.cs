using Microsoft.EntityFrameworkCore;
using PaparaFinalBase.Entity;
using PaparaFinalData.Context;

namespace PaparaProjectData.GenericRepository.GenericRepositoryBaseEntity
{
    public class GenericWriteRepositoryBaseEntity<TEntity> : IGenericWriteRepositoryBaseEntity<TEntity> where TEntity : BaseEntity
    {
        private readonly PaparaProjectDbContext dbContext;

        public GenericWriteRepositoryBaseEntity(PaparaProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            entity.IsActive = true;
            await dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            entity.IsActive = true;
            dbContext.Set<TEntity>().Update(entity);
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(dbContext.Set<TEntity>(), x => x.Id == Id);
            if (entity is not null)
            {
                dbContext.Set<TEntity>().Remove(entity);
                return true;
            }
            return false;
        }

        public async Task<bool> Disactivate(int Id)
        {
            var entity = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(dbContext.Set<TEntity>(), x => x.Id == Id);
            if (entity is not null)
            {
                entity.IsActive = false;
                return true;
            }
            return false;
        }
    }
}
