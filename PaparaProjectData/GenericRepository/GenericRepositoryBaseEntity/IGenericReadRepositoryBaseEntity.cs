using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.GenericRepository.GenericRepositoryBaseEntity
{
    public interface IGenericReadRepositoryBaseEntity<TEntity> where TEntity : class
    {
        Task Save();
        Task<TEntity?> GetById(int Id, params string[] includes);
        Task<List<TEntity>> GetAll(params string[] includes);
        Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression, params string[] includes);
    }
}
