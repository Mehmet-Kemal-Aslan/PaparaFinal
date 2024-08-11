using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaparaFinalData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.GenericRepository.GenericRepositoryIdentityUser
{
    public class GenericWriteRepositoryIdentityUser<TEntity> : IGenericWriteRepositoryIdentityUser<TEntity> where TEntity : IdentityUser
    {
        private readonly PaparaProjectDbContext dbContext;

        public GenericWriteRepositoryIdentityUser(PaparaProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(string Id)
        {
            var entity = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(dbContext.Set<TEntity>(), x => x.Id == Id);
            if (entity is not null)
                dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            IdentityUserRole<string> userRole = new IdentityUserRole<string>
            {
                UserId = entity.Id,
                RoleId = "2",
            };
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.Set<IdentityUserRole<string>>().AddAsync(userRole);
            var a = userRole;
            return entity;
        }
        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
    }
}
