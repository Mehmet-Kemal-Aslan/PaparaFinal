using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.GenericRepository.GenericRepositoryBaseEntity
{
    public interface IGenericWriteRepositoryBaseEntity<TEntity> where TEntity : class
    {
        Task Save();
        Task<TEntity> Insert(TEntity entity);
        void Update(TEntity entity);
        Task<bool> Delete(int Id);
        Task<bool> Disactivate(int Id);
    }
}
