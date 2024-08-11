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
    public class GenericReadRepositoryIdentityUser<TEntity> : IGenericReadRepositoryIdentityUser<TEntity> where TEntity : IdentityUser
    {
        private readonly PaparaProjectDbContext dbContext;

        public GenericReadRepositoryIdentityUser(PaparaProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetById(string Id, params string[] includes)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
            return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query, x => x.Id == Id);
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
